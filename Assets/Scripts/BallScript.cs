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
    private AudioSource efek;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Startball", 3);
        normalspeed = speed;
        efek = GetComponent<AudioSource>();
    }
    void Startball()
    {
        float randomAngle = Random.Range(-45f, 45f);

        float directionMultiplier = Random.Range(0, 2) == 0 ? -1f : 1f;

        float angleInRadians = randomAngle * Mathf.Deg2Rad;

        float xDirection = Mathf.Cos(angleInRadians) * directionMultiplier;
        float yDirection = Mathf.Sin(angleInRadians);

        rb.velocity = new Vector2(xDirection, yDirection).normalized * speed;
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
            efek.Play();
        }

        if (coll.gameObject.tag == "Player")
        {
            wallCollisionCount = 0;
            efek.Play();
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
