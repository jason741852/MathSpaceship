using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// CanvasManager controls all score, high score display
/// the accessors allow other GameObject to update UI element when an event happens
/// </summary>

public class CanvasManager : MonoBehaviour {
    IEnumerator coroutine;
    int highScore = 0;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        setHighScore(highScore);
    }
	
    public void setQuestionCanvas(string questionText)
    {
        transform.GetChild(2).GetComponent<Text>().text = questionText;
        coroutine = destroyQuestionCanvas(5f);
        StartCoroutine(coroutine);
    }

    IEnumerator destroyQuestionCanvas(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.GetChild(2).GetComponent<Text>().text = "";
    }

    public void setScore(string score)
    {
        transform.GetChild(1).GetComponent<Text>().text = score;
    }

    void setHighScore(int highScore)
    {
        transform.GetChild(4).GetComponent<Text>().text = string.Concat("Highest Score: ", highScore);
    }
}
