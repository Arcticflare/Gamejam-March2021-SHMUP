using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemySpawn;
    [SerializeField] float spawnTimer = 5;
    float elapsedTime = 0.0f;

    CameraBounds cb;
    Vector2 spawnArea;
    
    void Start()
    {
        cb = FindObjectOfType<CameraBounds>();
        spawnArea = cb.screenBounds;
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
        var position = new Vector2(Random.Range(-spawnArea.x, spawnArea.x), (Random.Range(-spawnArea.y, spawnArea.y)));
        Instantiate(enemySpawn, position, Quaternion.identity);
        
    }
}
