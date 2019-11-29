using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    private float fireRate = 0.35f;
    private float nextFire;

    //public FixedJoystick joyStick1;

    //public FixedJoystick joyStick2;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform shell;
    public Transform shellEjection;

    public float PlayerSpeed;
    private Animator anim;
    public AudioSource GunShot;

    /*

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        //rigidbody.velocity = new Vector3(joyStick1.Horizontal * PlayerSpeed, rigidbody.velocity.y, joyStick1.Vertical * PlayerSpeed);


        //Vector3 playerDirection = Vector3.right * joyStick2.Horizontal + Vector3.forward * joyStick2.Vertical;
        /*if (playerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            if (Time.time > nextFire)
            {
                fire();
                anim.SetTrigger("Shoot");
                nextFire = Time.time + fireRate;
            }
        }




    }
    void fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        Instantiate(shell, shellEjection.position, shellEjection.rotation);

        GunShot.Play();
    }*/

}
