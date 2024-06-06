using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementspeed;
    [SerializeField] private bool isbot;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playermove;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isbot)
        {
            botcontrol();
        }

        else
        {
            playercontrol();
        }
    }
    private void playercontrol()
    {
        playermove = new Vector2(0, Input.GetAxis("Vertical"));
    }
    private void botcontrol()
    {
        if(ball.transform.position.y > transform.position.y + 0.5f) 
        {
            playermove = new Vector2(0, 1);
        }

        if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playermove = new Vector2(0, -1);
        }

        else
        {
            playermove = new Vector2(0, 1);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = playermove * movementspeed;
    }
}
