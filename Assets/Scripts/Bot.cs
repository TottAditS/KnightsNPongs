using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public Transform ball;
    public Transform enemy;
    public float speed = 1f;
    private Vector2 destination;

    public void MoveToBall()
    {
        destination = new Vector2(enemy.transform.position.x, ball.position.y);
        transform.position = Vector2.Lerp(enemy.transform.position, destination, speed * Time.deltaTime);
    }

    void Update()
    {
        MoveToBall();
    }
}