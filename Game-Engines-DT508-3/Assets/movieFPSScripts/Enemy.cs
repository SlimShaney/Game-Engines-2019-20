using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent nav;
    Transform player;
    Animator anim;

    private Score scoreScript;

    public int pointValue = 30;
    public float health = 5f;
    public bool die = false;

    //public float playerHealth = 100;
    float EnemiesKilled;

    private WaitForSeconds Destroy = new WaitForSeconds(2f);
    private WaitForSeconds Attack = new WaitForSeconds(2.1f);

    private float damageRate = 3.0f;
    private float nextDamage;

    void Awake()
    {    
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update () 
    {
        nav.SetDestination(player.transform.position);
    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0)
        {
            Die();
            GameManagement.AddPoints(pointValue);
        }
    }

    public void Die()
    {
        EnemySpawn.enemiesKilled++;
        Debug.Log(EnemySpawn.enemiesKilled);        
        StartCoroutine(DieAnimation());               
    }

    public void HurtPlayer()
    {
        if (Time.time > nextDamage)
        {
            //PlayerHealth.playerHealth -= 20;
            nextDamage = Time.time + damageRate;
        }
    }

    private IEnumerator DieAnimation()
    {
        anim.SetBool("Die", true);
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;                
        yield return Destroy;
        Destroy(gameObject);
    }

    IEnumerator OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("MainCamera"))
        {            
            Debug.Log("DAMAGE");   
            anim.SetTrigger("Attacking");
            HurtPlayer();
            yield return Attack;
            Die();
        }
    }
}
