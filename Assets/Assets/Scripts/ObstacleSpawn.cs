using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawn : MonoBehaviour {
    public GameObject obstacle;
    public int maxPlatforms = 5;
    public float horizontalMin = -2.9f;
    public float horizontalMax = 2.9f;
    public float verticalMin = 3f;
    public float verticalMax = 6f;
    public Vector2 speed = new Vector2(0, -3f);

    private float screenWidth = Screen.width/2;
    private Rigidbody2D rb;

    private Vector2 originalPosition;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        originalPosition = transform.position;
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
        var pos = rb.position + speed * Time.deltaTime;

        rb.MovePosition(pos);

    }

    void Spawn()
    {
        for(int i=0; i< maxPlatforms; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-screenWidth, screenWidth), originalPosition.y + Random.Range(3f, 6f));
            GameObject obst = (GameObject)Instantiate(obstacle, randomPosition, Quaternion.identity);
            Transform t = obst.transform;
            t.parent = transform;

            originalPosition = randomPosition;
        }
    }


}
