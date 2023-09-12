using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool topDownMode;

    int directionX, directionY;
    float playerSpeedX, playerSpeedY;

    Rigidbody2D rigBody;

    private void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();

        if (topDownMode)
        {
            if (rigBody.gravityScale > 0)
            {
                rigBody.gravityScale = 0;
            }
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            directionX = 1;
            playerSpeedX = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            directionX = -1;
            playerSpeedX = speed;
        }
        else
        {
            directionX = 0;
            playerSpeedX = 0;
        }

        if (topDownMode)
        {
            if (Input.GetKey(KeyCode.W))
            {
                directionY = 1;
                playerSpeedY = speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                directionY = -1;
                playerSpeedY = speed;
            }
            else
            {
                directionY = 0;
                playerSpeedY = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        rigBody.velocity = new Vector2(playerSpeedX * directionX, playerSpeedY * directionY);
    }
}
