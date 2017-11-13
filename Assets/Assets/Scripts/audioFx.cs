using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFx : MonoBehaviour {
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
    // Use this for initialization
    void Start () {
        music = GetComponent<AudioSource>();
        Debug.Log(this);
        instance = this;
    }

}
