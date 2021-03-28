using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        EnemyStatus es = other.GetComponent<EnemyStatus>();
        
        if(es != null)
        {
            es.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
