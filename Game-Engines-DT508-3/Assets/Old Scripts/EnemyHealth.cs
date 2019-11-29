using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    Animator anim;

    private Score scoreScript;

    public int pointValue = 30;
    public float health = 5f;
    public bool die = false;

    //public float playerHealth = 100;
    float EnemiesKilled;

    private WaitForSeconds DestroyZombie = new WaitForSeconds(0.5f);


    public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0/*.1f*/)
        {
            Die();
            //GameManagement.AddPoints(pointValue);
        }
    }

    public void Die()
    {
        EnemySpawn.enemiesKilled++;
        Debug.Log(EnemySpawn.enemiesKilled);
        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(DieAnimation());               
    }

    private IEnumerator DieAnimation()
    {
        anim.SetBool("Die", true);
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        yield return DestroyZombie;
        Destroy(gameObject);
        //scoreScript.score++;
        //EnemySpawn.EnemiesKilled++;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //playerHealth -= 5;
            Debug.Log("DAMAGE");
            Die();
        }
    }
}
