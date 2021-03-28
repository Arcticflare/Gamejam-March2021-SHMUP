using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float left; 
    float right; 
    float down; 
    float up; 
    Rigidbody2D rb;

    [SerializeField]
    float moveTime = 2;
    float elapsedTime = 0.0f;
    [SerializeField]
    float moveDistance = 10;
    [SerializeField]
    float moveSpeed = 10;

    void Start()
    {
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
            // Find the algo to move to this position with velocity.
            // Start position to transform.
            transform.position = new Vector2(Random.Range(left, right), (Random.Range(down, up)));
            elapsedTime = 0;
        }
    }

    
}
