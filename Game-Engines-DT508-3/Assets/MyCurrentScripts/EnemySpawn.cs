using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] whatToSpawn;

    public Mesh[] shipMeshes;
    public Material[] shipColours;

    public float spawnTime;

    private Score scoreScript;
    
    void Start()
    {       
        StartCoroutine(Timer());
        scoreScript = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Score>();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(spawnTime);
        if (scoreScript.boids < 100)
        {
            SpawnEnemy();
        }
        StartCoroutine(Timer());
    }

    public void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        transform.localRotation = Quaternion.identity;
        Instantiate(whatToSpawn[Random.Range(0, whatToSpawn.Length)], randomSpawnPoint, Quaternion.identity);
        //Debug.Log("Spawn Asteroid.");
    }
    
    
}
