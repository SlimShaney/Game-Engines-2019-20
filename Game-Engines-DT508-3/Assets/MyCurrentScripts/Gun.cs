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
    private AudioSource gunShot;
    public AudioSource gunReload;
    //private turretsFire shootScript;

    public bool isReloading;

    public TMP_Text ammoCount;
    
    void Start()
    {
        //shootScript = GetComponentInParent<turretsFire>();
        currentAmmo = fullAmmo;
        damage = 1;
        gunShot = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        ammoCount.text = currentAmmo + "/" + fullAmmo;
    }

    public void Shoot()
    {
        gunShot.Play();
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        //Debug.Log("Reload");
        gunReload.Play();
        yield return new WaitForSeconds(reloadTime);
        //Debug.Log("Reloaded");

        currentAmmo = fullAmmo;
        isReloading = false;
    }
}
