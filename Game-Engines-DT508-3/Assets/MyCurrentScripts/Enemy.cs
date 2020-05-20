using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    /*public int pointValue;
    public float health;
    public float speed;
    public float step;
    */
    public float damage;
    
    private Score scoreScript;
    private Health playerHealthScript; 
    
    //public GameObject player;
    public GameObject spawnArea;
    public GameObject explosionEffect;

    public AudioSource explosion;

    void Awake()
    {    
        //player = GameObject.FindGameObjectWithTag("Player");
        spawnArea = GameObject.FindGameObjectWithTag("Respawn");
        //scoreScript = player.GetComponentInChildren<Score>();
        explosion = spawnArea.GetComponent<AudioSource>();
    }

    void Update ()
    {
        //step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    /*public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Explode();
            scoreScript.AddPoints(pointValue);
        }
    }*/
    public void HurtPlayer(float damageDealt)
    {
        playerHealthScript.TakeDamage(damageDealt);
    }

    public void Explode()
    {
        explosion.Play();
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {            
            //Debug.Log("DAMAGE");
            playerHealthScript = col.gameObject.GetComponent<Health>();
            HurtPlayer(damage);
            Explode();
        }
    }
}
