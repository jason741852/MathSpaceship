﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// QuestionGateSpawnManager spawns all obstacles and question gates at Start
/// </summary>

public class QuestionGateSpawnManager : MonoBehaviour {
    List<GameObject> QuetionGateList = new List<GameObject>();
    public GameObject QuestionGate1;
    public GameObject QuestionGate2;
    public GameObject QuestionGate3;
    public GameObject obstacle;

    public float obstacleHorizontalMin = -2.9f;
    public float obstacleHorizontalMax = 2.9f;
    public float obstacleVerticalMin = 3f;
    public float obstacleVerticalMax = 6f;
    float screenWidth = Screen.width / 2;

    Rigidbody2D rb, obstacleManagerRb;

    public Vector2 speed = new Vector2(0, -3f);
    Vector2 originalPosition;

    public int maxObstacles;
    public int maxQuestionPhase;
    int triggerCount = 0;

    CanvasManager canvasManager;
    string questionText;
    Queue<string> questionQueue = new Queue<string>(); // queue to store all questions

    int GateIndex; // Index for easy randomization method

    int x, y, answer, falseAnswer1, falseAnswer2;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        QuetionGateList.Add(QuestionGate1);
        QuetionGateList.Add(QuestionGate2);
        QuetionGateList.Add(QuestionGate3);

        // Obstacle assignment
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        originalPosition = transform.position;
        SpawnQuestions();

    }
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.position + speed * Time.deltaTime);
    }

    public void SpawnQuestions()
    {
        for (int i = 0; i < maxQuestionPhase; i++)
        {
            SpawnObstacles();
            Vector2 randomPosition = new Vector2(0, originalPosition.y + 10);

            GenerateQuestionsAndAnswers();

            questionText = string.Concat(x, " + ", y, " = ?");
            questionQueue.Enqueue(questionText);

            GateIndex = PickRandomGate();

            GameObject QuestionGate = (GameObject)Instantiate(QuetionGateList[GateIndex], randomPosition, Quaternion.identity, transform);
            AssignAnswer(QuestionGate, answer, falseAnswer1, falseAnswer2, GateIndex);

            originalPosition = randomPosition;
            originalPosition += new Vector2(0, 10f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            triggerCount++;
        }

        // Dequeue a question to canvas to display
        if (!other.gameObject.CompareTag("deletionTrigger") && triggerCount%2 == 1)
        {
            canvasManager.setQuestionCanvas(questionQueue.Dequeue());
        }
    }

    /// <summary>
    /// Assign answer randomly based on random GateIndex
    /// </summary>
    void AssignAnswer(GameObject QuestionGate, int RightAnswer, int FalseAnswer1, int FalseAnswer2, int GateIndex)
    {
        if (GateIndex == 0)
        {
            QuestionGate.transform.GetChild(4).GetComponent<Text>().text = FalseAnswer1.ToString();
            QuestionGate.transform.GetChild(5).GetComponent<Text>().text = RightAnswer.ToString();
            QuestionGate.transform.GetChild(6).GetComponent<Text>().text = FalseAnswer2.ToString();
        }
        else if (GateIndex == 1)
        {
            QuestionGate.transform.GetChild(3).GetComponent<Text>().text = RightAnswer.ToString();
            QuestionGate.transform.GetChild(4).GetComponent<Text>().text = FalseAnswer1.ToString();
            QuestionGate.transform.GetChild(5).GetComponent<Text>().text = FalseAnswer2.ToString();
        }
        else if (GateIndex == 2)
        {
            QuestionGate.transform.GetChild(3).GetComponent<Text>().text = FalseAnswer1.ToString();
            QuestionGate.transform.GetChild(4).GetComponent<Text>().text = FalseAnswer2.ToString();
            QuestionGate.transform.GetChild(5).GetComponent<Text>().text = RightAnswer.ToString();
        }
    }

    void GenerateQuestionsAndAnswers()
    {
        x = Random.Range(2, 15);
        y = Random.Range(2, 15);
        answer = x + y;

        // Need to make sure all numbers are unique
        falseAnswer1 = Random.Range(2, 15) + Random.Range(2, 15);
        while (falseAnswer1 == answer)
        {
            falseAnswer1 = Random.Range(2, 15) + Random.Range(2, 15);
        }
        falseAnswer2 = Random.Range(2, 15) + Random.Range(2, 15);
        while (falseAnswer2 == answer || falseAnswer2 == falseAnswer1)
        {
            falseAnswer2 = Random.Range(2, 15) + Random.Range(2, 15);
        }
    }

    int PickRandomGate()
    {
        return Random.Range(0, 3);
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < maxObstacles; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-screenWidth, screenWidth), originalPosition.y + Random.Range(3f, 6f));
            GameObject obst = (GameObject)Instantiate(obstacle, randomPosition, Quaternion.identity);
            Transform t = obst.transform;
            t.parent = transform;

            originalPosition = randomPosition;
        }
    }

}
