using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// StartMenu is the first script to run in the game,
/// it disables other Manager components until the "Start" button is hit
/// </summary>

public class StartMenu : MonoBehaviour {
    QuestionGateSpawnManager spawnScript;
    PlayerManager playerManager;
    Button btn;
    GameObject LeftButton, RightButton;

    void Awake()
    {
        spawnScript = GameObject.FindObjectOfType(typeof(QuestionGateSpawnManager)) as QuestionGateSpawnManager;
        spawnScript.enabled = false;
        playerManager = GameObject.FindObjectOfType(typeof(PlayerManager)) as PlayerManager;
        playerManager.enabled = false;
    }

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
        playerManager.enabled = true;
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
