using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour {
    private int highScore = 0;
    

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        GetComponent<Text>().text = string.Concat("Highest Score: ", highScore);
	}
	
	public int getCurrentHighScore()
    {
        return highScore;
    }

    public void setHighScore(int newScore)
    {
        highScore = newScore;
        Debug.Log(newScore);
        GetComponent<Text>().text = string.Concat("Highest Score: ", highScore);
    }
}
