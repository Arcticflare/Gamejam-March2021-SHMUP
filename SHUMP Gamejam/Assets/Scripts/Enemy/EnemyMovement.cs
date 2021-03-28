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
    float speed = 5;
    float elapsedTime = 0.0f;

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
            MoveEnemy();
        }


    }

    // Managed to get this working using the direction var, but had no bounds set.
    // Consider just setting bounds as player has.
    void MoveEnemy()
    {
        //var direction = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        var randomPos = new Vector2(Random.Range(left, right), (Random.Range(down, up)));

        // Using deltaTime causes this to stop working? 
        float step =  speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, randomPos, speed);
    }


}
