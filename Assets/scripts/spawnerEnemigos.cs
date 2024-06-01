using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerEnemigos : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform spawnPoint; 
    public float minSpawnInterval = 1f; 
    public float maxSpawnInterval = 3f; 
    public int maxEnemies = 5; 
    private int currentEnemies = 0; 
    private float spawnTimer = 0f;
    public string bouncer;

    private void Update()
    {
        
        if (currentEnemies < maxEnemies)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= Random.Range(minSpawnInterval, maxSpawnInterval))
            {
                SpawnEnemy();
                spawnTimer = 0f;
                
            }
        }        
    }

    private void SpawnEnemy()
    {
        
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, enemyPrefab.transform.rotation);
        currentEnemies++;

        newEnemy.GetComponent<enemigo>().ID = bouncer;
    }
}
