using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipSpawnSettings : MonoBehaviour
{
    #region
    private MeshFilter shipBody;
    private Renderer shipColour;
    private EnemySpawn esScript;
    private GameObject gameManager;

    private Score scoreScript;
    #endregion
    
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        esScript = gameManager.GetComponent<EnemySpawn>();
        
        shipBody = GetComponent<MeshFilter>();
        shipBody.mesh = esScript.shipMeshes[Random.Range(0, esScript.shipMeshes.Length)];

        shipColour = GetComponent<Renderer>();
        shipColour.material = esScript.shipColours[Random.Range(0, esScript.shipColours.Length)];

        scoreScript = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Score>();
        scoreScript.boids++;
    }
}
