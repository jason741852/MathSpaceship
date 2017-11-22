using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AudioFx is responsible for the background game music
/// </summary>

public class AudioFx : MonoBehaviour {
    static Object instance = null;
    AudioSource music;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    void Start () {
        music = GetComponent<AudioSource>();
        Debug.Log(this);
        instance = this;
    }

}
