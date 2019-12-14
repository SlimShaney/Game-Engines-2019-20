using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private turretsFire shootScript;

    public TMP_Text ammoCount;
    
    void Start()
    {
        shootScript = GetComponentInParent<turretsFire>();
        currentAmmo = fullAmmo;
        damage = 1;

        animator = gameObject.GetComponent<Animator>();
        gunShot = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        ammoCount.text = currentAmmo + "/" + fullAmmo;
    }

    public void Shoot()
    {
        //gunShot.Play();
        //animator.SetTrigger("Shoot");
    }

    public IEnumerator Reload()
    {
        shootScript.isReloading = true;
        Debug.Log("Reload");
        //animator.SetTrigger("Reload");
        //gunReload.Play();
        yield return new WaitForSeconds(reloadTime);
        //anim.SetBool("Reloading", false);
        //yield return new WaitForSeconds(reloadTime);
        Debug.Log("Reloaded");

        currentAmmo = fullAmmo;
        shootScript.isReloading = false;
    }
}
