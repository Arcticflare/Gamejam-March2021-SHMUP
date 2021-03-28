using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float left; 
    float right; 
    float down; 
    float up; 
    [SerializeField]
    GameObject EnemySpawn;
    [SerializeField]
    float spawnTimer = 5;
    float elapsedTime = 0.0f;
    
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

        if (elapsedTime > spawnTimer)
        {
            elapsedTime = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        var pos = new Vector2(Random.Range(left, right), (Random.Range(down, up)));
        Instantiate(EnemySpawn, pos, Quaternion.identity);
        
    }
}
