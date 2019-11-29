using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {
    
    [SerializeField] public int round = 1;
    [SerializeField] int EnemiesPerRound;
    [SerializeField] public static int EnemiesSpawned = 0;
    float EnemySpawnTimer = 0f;
    [SerializeField] float EnemiesAlive = 0;
    [SerializeField] public static int EnemiesKilled = 0;
    float spawnRate;


    static int playerScore = 0;
    public static float finalScore;

    void Start () {
        spawnRate = 4f;
	}

    void Update() {
        EnemiesPerRound = (10 * round);
        
        if (EnemiesSpawned < EnemiesPerRound)
        {
            if (Time.time > spawnRate)
            {
                spawnEnemy();
                spawnRate = Time.time + spawnRate;      
            }
        }
        
       EnemiesAlive = EnemiesSpawned - EnemiesKilled;

    }

    public static void AddPoints(int pointValue)
    {
        playerScore += pointValue;
    }


    void spawnEnemy()
    {

        EnemiesSpawned++;

    }

}
