using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverCheck : MonoBehaviour {
    ScoreUpdate scoreUpdate;
    int maxScore;

    // Use this for initialization
    void Start () {
        scoreUpdate = GetComponent<ScoreUpdate>();
        maxScore = 5;
    }
	
	// Update is called once per frame
	void Update () {
        if(scoreUpdate.getScore() >= maxScore)
        {
            reloadScreen();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            setHighScore();
            SceneManager.LoadScene("GamePlay");
            

        }
    }

    void reloadScreen()
    {
        setHighScore();
        SceneManager.LoadScene("GamePlay");


    }

    void setHighScore()
    {
        int prevScore;
        if (PlayerPrefs.HasKey("highScore"))
        {
            prevScore = PlayerPrefs.GetInt("highScore");
            if(scoreUpdate.getScore() > prevScore)
            {
                PlayerPrefs.SetInt("highScore", scoreUpdate.getScore());
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", scoreUpdate.getScore());
        }

    }
}
