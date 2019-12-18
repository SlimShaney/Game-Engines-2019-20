using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public sceneLoader sceneManager;

    void Start()
    {
        currentHealth = maxHealth;
        sceneManager = GetComponentInChildren<sceneLoader>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            sceneManager.LoadMenu();
            Destroy(this.gameObject);
            Debug.Log(this.gameObject.name + " destroyed.");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
    }
}
