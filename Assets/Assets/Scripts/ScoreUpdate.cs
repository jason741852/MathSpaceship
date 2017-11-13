using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

    private Transform scoreText;
    private int score = 0;
    private string strintOutput = "Score: ";
	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("Canvas").transform.GetChild(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreTag"))
        {
            score++;
            scoreText.GetComponent<Text>().text = string.Concat(strintOutput, score);
        }
    }

    public int getScore()
    {
        return score;
    }
}
