using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


/// <summary>
/// Player Manager keeps the score of the player,
/// check for game over conditions,
/// and call Canvas Manager to update score on display when needed
/// </summary>


public class PlayerManager : MonoBehaviour {
    int maxScore;
    Transform scoreText;
    int score = 0;
    string strintOutput = "Score: ";
    CanvasManager canvasManager;

    // Use this for initialization
    void Start () {
        maxScore = GameObject.Find("QuestionManager").GetComponent<QuestionGateSpawnManager>().maxQuestionPhase;
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
    }
	
    // Update is called once per frame
    void Update () {
        // Reload the game to home screen if player has hit max score
        if (getScore() >= maxScore)
        {
            ReloadScreen();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            setHighScore();
            ReloadScreen();


        }
        if (other.gameObject.CompareTag("ScoreTag"))
        {
            score++;
            canvasManager.setScore(string.Concat(strintOutput, score));
        }
    }

    void ReloadScreen()
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
            if (getScore() > prevScore)
            {
                PlayerPrefs.SetInt("highScore", getScore());
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", getScore());
        }

    }

    public int getScore()
    {
        return score;
    }
}
