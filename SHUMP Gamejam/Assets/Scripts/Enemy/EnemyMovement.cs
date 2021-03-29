using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float moveTime = 2;
    [SerializeField]
    float speed = 5.0f;
    float elapsedTime = 0.0f;
    Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
