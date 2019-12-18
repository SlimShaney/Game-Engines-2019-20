using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Score scoreScript;

    public int pointValue = 3;
    public float health = 5f;
    public float speed = 3f;
    public float step;
    
    public Transform playerPosition;

    void Awake()
    {    
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;       
    }

    void Update ()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, step);
    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0)
        {
            Explode();
            GameManagement.AddPoints(pointValue);
        }
    }
    public void HurtPlayer()
    {
        return;
    }

    private void Explode()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {            
            Debug.Log("DAMAGE");   
            HurtPlayer();
            Explode();
        }
    }
}
