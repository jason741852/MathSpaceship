using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Game Over?");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("obstacle"))
        {
            SceneManager.LoadScene("GamePlay");
        }
    }
}
