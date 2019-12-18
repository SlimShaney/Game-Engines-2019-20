using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] asteroids;

    public float spawnTime;
    
    void Start()
    {       
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(spawnTime);        
        SpawnEnemy();        
        StartCoroutine(Timer());
    }

    public void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        transform.localRotation = Quaternion.identity;
        Instantiate(asteroids[Random.Range(0, asteroids.Length)], randomSpawnPoint, Quaternion.identity);
        //Debug.Log("Spawn Asteroid.");
    }
    
    
}
