using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    #region Variables
    
    [SerializeField] public static int round;
    [SerializeField] public static int enemiesPerRound;
    [SerializeField] int enemiesSpawned;
    [SerializeField] public static float enemiesAlive;
    [SerializeField] public static int enemiesKilled;

    public Transform[] spawnPoints;
    public GameObject[] enemies;

    public float spawnTime;
    
    #endregion
    
    void Start()
    {
        round = 1;        
        StartCoroutine(Timer());
    }

    void Update()
    {
        
        enemiesPerRound = (5 * round);
        enemiesAlive = enemiesSpawned - enemiesKilled;

        if (enemiesKilled < enemiesPerRound) return;
        round++;
        enemiesAlive = 0;
        enemiesSpawned = 0;
        enemiesKilled = 0;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(spawnTime - (round / 5));
        
        if (enemiesSpawned < enemiesPerRound)
        {
            SpawnEnemy();
            enemiesSpawned++;
        }
        
        StartCoroutine(Timer());
    }

    public void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        transform.localRotation = Quaternion.identity;
        Instantiate(enemies[Random.Range(0, enemies.Length)], randomSpawnPoint, Quaternion.identity);
        Debug.Log("Spawn.");
    }
    
    
}
