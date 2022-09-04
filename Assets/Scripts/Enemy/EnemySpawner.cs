using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject enemy;
    private int randomSpawnPoint;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            
            if (spawnPoints[randomSpawnPoint].transform.position.x > 0)
            {
                Instantiate(enemy, spawnPoints[randomSpawnPoint].transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            else if (spawnPoints[randomSpawnPoint].transform.position.x < 0)
            {
                Instantiate(enemy, spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
            }
            
        }
    }
}
