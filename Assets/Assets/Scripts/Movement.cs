using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

using UnityEngine;

public class Movement : EventTrigger
{
    private Vector2 speed = new Vector2(4f, 0);
    private bool buttonDown = false;
    private Rigidbody2D rb;
    private float screenWidth;
    private float spaceshipWidth;

    Vector2 playerPosScreen;

    protected Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        screenWidth = Screen.width;

        spaceshipWidth = GameObject.Find("Player").GetComponent<Renderer>().bounds.size.x;
        
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        playerPosScreen = Camera.main.WorldToScreenPoint(rb.position);
        if (buttonDown)
        {
            if(gameObject.name == "RightButton")
            {
                if (playerPosScreen.x < screenWidth - spaceshipWidth)
                {
                    var pos = rb.position + speed * Time.deltaTime;
                    pos.x = Mathf.Clamp(pos.x, -screenWidth, screenWidth);
                    rb.MovePosition(pos);
                }
            }
            else if (gameObject.name == "LeftButton")
            {
                if (playerPosScreen.x > spaceshipWidth)
                {
                    var pos = rb.position - speed * Time.deltaTime;
                    pos.x = Mathf.Clamp(pos.x, -screenWidth, screenWidth);
                    rb.MovePosition(pos);
                }
            }

        }
    }

    public override void OnPointerDown(PointerEventData data)
    {
        Debug.Log("OnPointerDown called.");
        buttonDown = true;
    }

    public override void OnPointerUp(PointerEventData data)
    {
        buttonDown = false;
    }


}
