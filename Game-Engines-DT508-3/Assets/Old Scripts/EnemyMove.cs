using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    /*public AudioClip Zombie1;
    public AudioClip Zombie2;
    public AudioClip Zombie3; */

    UnityEngine.AI.NavMeshAgent nav;
    Transform gate;
    protected Animator myAnimation;
    Animator controller;

    public float timeToAttack;
    float attackTimer;

    void Awake()
    {
        //SoundManager.instance.RandomizeSfx(Zombie1, Zombie2, Zombie3);
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        gate = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GetComponentInParent<Animator>();
    }

    void Update () {
        nav.SetDestination(gate.position);
        //controller.SetFloat("Speed", Mathf.Abs(nav.velocity.x) + Mathf.Abs(nav.velocity.z));
        float distance = Vector3.Distance(transform.position, gate.position);

    }

}
