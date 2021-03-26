using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float health = 10;
    public void TakeDamage (int damage)
    {
        health -= damage;

        if  (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Dead.");
    }
}
