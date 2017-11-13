using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGateSpawnManager : MonoBehaviour {
    private List<GameObject> QuetionGateList = new List<GameObject>();
    public GameObject QuestionGate1;
    public GameObject QuestionGate2;
    public GameObject QuestionGate3;
    private Rigidbody2D rb;
    string questionText;
    private IEnumerator coroutine;

    public Vector2 speed = new Vector2(0, -3f);
    private Vector2 originalPosition;
    public int maxPlatforms = 1;
    private Queue<string> questionQueue = new Queue<string>();

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        QuetionGateList.Add(QuestionGate1);
        QuetionGateList.Add(QuestionGate2);
        QuetionGateList.Add(QuestionGate3);

        originalPosition = transform.position;
        SpawnQuestions();

    }
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.position + speed * Time.deltaTime);
    }

    public void SpawnQuestions()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = new Vector2(0, originalPosition.y + 20);

            int x = Random.Range(2, 15);
            int y = Random.Range(2, 15);
            int answer = x + y;
            int falseAnswer1 = Random.Range(2, 15) + Random.Range(2, 15);
            int falseAnswer2 = Random.Range(2, 15) + Random.Range(2, 15);
            questionText = string.Concat(x, " + ", y, " = ?");
            questionQueue.Enqueue(questionText);

            int GateIndex = Random.Range(0, 3);

            GameObject QuestionGate = (GameObject)Instantiate(QuetionGateList[GateIndex], randomPosition, Quaternion.identity, transform);

            AssignAnswer(QuestionGate, answer, falseAnswer1, falseAnswer2, GateIndex);

            originalPosition = randomPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        GameObject.Find("Question_Canvas").transform.GetChild(0).GetComponent<Text>().text = questionQueue.Dequeue();
        Debug.Log(name);
        coroutine = destroyQuestionCanvas(5f);
        StartCoroutine(coroutine);
    }

    private IEnumerator destroyQuestionCanvas(float waitTime)
    {
        Debug.Log("coroutine started");
        yield return new WaitForSeconds(waitTime);
        GameObject.Find("Question_Canvas").transform.GetChild(0).GetComponent<Text>().text = "";
    }

    private void AssignAnswer(GameObject QuestionGate, int RightAnswer, int FalseAnswer1, int FalseAnswer2, int GateIndex)
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

}
