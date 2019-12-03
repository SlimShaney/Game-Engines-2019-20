using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int fullAmmo;
    public int currentAmmo;
   
    public int damage;
    public float fireRate;
    public float range;
    public float reloadTime;
    
    public Transform barrelTip;

    private Animator animator;
    private AudioSource gunShot;
    private Shoot shootScript;
    
    void Start()
    {
        shootScript = GetComponentInParent<Shoot>();
        currentAmmo = fullAmmo;

        animator = gameObject.GetComponent<Animator>();
        gunShot = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    public void Shoot()
    {
        gunShot.Play();
        animator.SetTrigger("Shoot");
    }

    public IEnumerator Reload()
    {
        shootScript.isReloading = true;
        Debug.Log("Reload");
        animator.SetTrigger("Reload");
        //gunReload.Play();
        yield return new WaitForSeconds(reloadTime);
        //anim.SetBool("Reloading", false);
        //yield return new WaitForSeconds(reloadTime);
        Debug.Log("Reloaded");

        currentAmmo = fullAmmo;
        shootScript.isReloading = false;
    }
}
