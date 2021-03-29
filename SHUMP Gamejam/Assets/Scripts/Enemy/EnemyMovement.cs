using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float left;
    float right;
    float down;
    float up;

    [SerializeField]
    float moveTime = 2;
    [SerializeField]
    float speed = 5.0f;
    float elapsedTime = 0.0f;
    Vector2 direction;
    bool moving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        up = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        down = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > moveTime)
        {
            elapsedTime = 0;
            direction = GetDirection();
            rb.velocity = direction;
        }
    }

    Vector2 GetDirection()
    {
        return new Vector2(Random.Range(-5, 5), (Random.Range(-5, 5)));
    }


}
