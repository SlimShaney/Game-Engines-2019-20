using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log(this.gameObject.name + " destroyed.");
        }
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.CompareTag == "Player")
        {
            Debug.Log("Player Hit");
        }
    }*/

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
    }
}
