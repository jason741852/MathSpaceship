using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
    QuestionGateSpawnManager spawnScript;
    GameOverCheck gameOverCheck;
    private Button btn;
    private GameObject LeftButton, RightButton;
    //private AudioSource fxSound;
    //public AudioClip backgroundMusic;

    void Awake()
    {
        spawnScript = GameObject.FindObjectOfType(typeof(QuestionGateSpawnManager)) as QuestionGateSpawnManager;
        spawnScript.enabled = false;
        gameOverCheck = GameObject.FindObjectOfType(typeof(GameOverCheck)) as GameOverCheck;
        gameOverCheck.enabled = false;
    }

	// Use this for initialization
	void Start () {
        // Commented out for desktop version
        //Screen.SetResolution(283, 453, false);
        btn = GetComponent<Button>();
        btn.onClick.AddListener(startSpawn);

        disableGUI();

    }

    void startSpawn()
    {
        spawnScript.enabled = true;
        gameOverCheck.enabled = true;
        EnableGUI();
    }

    void disableGUI()
    {
        LeftButton = GameObject.Find("LeftButton");
        RightButton = GameObject.Find("RightButton");
        GameObject.Find("LeftButton").SetActive(false);
        GameObject.Find("RightButton").SetActive(false);
    }

    void EnableGUI()
    {
        LeftButton.SetActive(true);
        RightButton.SetActive(true);
        GameObject.Find("StartButton").SetActive(false);
        GameObject.Find("HighScore").SetActive(false);
        GameObject.Find("Title").SetActive(false);
    }
}
