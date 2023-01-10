using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    private int enemySpawnCounter = 0;

    /*[SerializeField]
    private GameObject enemyPrefab;*/

    [SerializeField]
    private float spawningInterval = 5;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawningInterval));
    }

    /*private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if (enemySpawnCounter < Random.Range(15,20)){
            enemySpawnCounter += 1;
            yield return new WaitForSeconds(interval);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            int enemySpawned = Random.Range(0, 1);
            GameObject newEnemy = Instantiate(enemies[enemySpawned], spawnPoints[randSpawnPoint].position, transform.rotation);
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }*/

    private IEnumerator spawnEnemy(float interval)
    {
        if (enemySpawnCounter < Random.Range(15, 20))
        {
            enemySpawnCounter += 1;
            yield return new WaitForSeconds(interval);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            int enemySpawned = Random.Range(0, 2);
            GameObject newEnemy = Instantiate(enemies[enemySpawned], spawnPoints[randSpawnPoint].position, transform.rotation);
            StartCoroutine(spawnEnemy(interval));
        }
    }

}
