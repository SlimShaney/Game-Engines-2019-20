using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float pointValue;

    private GameObject gameManager;
    
    private Score scoreScript;
    private Enemy enemyScript;

    public sceneLoader sceneManager;

    void Awake()
    {
        currentHealth = maxHealth;
        enemyScript = GetComponent<Enemy>();
        sceneManager = GetComponentInChildren<sceneLoader>();
        
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        scoreScript = gameManager.GetComponentInChildren<Score>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            //sceneManager.LoadMenu();
            enemyScript.Explode();
            Destroy(this.gameObject);
            Debug.Log(this.gameObject.name + " destroyed.");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        scoreScript.AddPoints(pointValue);
    }
}
