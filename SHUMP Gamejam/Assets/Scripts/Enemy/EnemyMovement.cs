using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float left; 
    float right; 
    float down; 
    float up; 
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    float speed = 10;
    [SerializeField]
    float spawnAmount = 1;

    void Start()
    {
        // Get the in-game coordinates for the edge of the screen
        right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        up = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        down = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        SpawnEnemy(spawnAmount);
    }

    void Update()
    {
        
    }

    void SpawnEnemy(float amount)
    {
        var pos = new Vector2(Random.Range(left, right), (Random.Range(down, up)));
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
