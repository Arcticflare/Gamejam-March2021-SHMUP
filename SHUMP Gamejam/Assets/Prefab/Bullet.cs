using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    /* private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other.name);
        Destroy(gameObject);
    } */
}
