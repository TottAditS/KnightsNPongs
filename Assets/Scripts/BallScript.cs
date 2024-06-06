using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private int wallCollisionCount;
    public Rigidbody2D rb;
    public float speed;
    private float normalspeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Startball", 3);
        normalspeed = speed;
    }
    void Startball()
    {
        float rol = Random.Range(0, 2);

        if (rol < 0)
        {
            rb.velocity = new Vector2(20, -15).normalized * speed;
        }

        else
        {
            rb.velocity = new Vector2(20, 15).normalized * speed;
        }
        
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        speed = normalspeed;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("Startball", 1);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            speed = speed + 1;
            wallCollisionCount = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y).normalized * speed;
        }

        else
        {
            wallCollisionCount = wallCollisionCount + 1;
            if (wallCollisionCount > 6)
            {
                wallCollisionCount = 0;
                RestartGame();
            }
        }
    }
}
