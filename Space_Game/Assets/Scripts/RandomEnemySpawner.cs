using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    //public GameObject[] enemyPrefabs;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawningInterval = 5f;


    void Start()
    {
        StartCoroutine(spawnEnemy(spawningInterval, enemyPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0) & Time.timeScale != 0f) {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
        }*/
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemy, spawnPoints[randSpawnPoint].position, transform.rotation);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
