using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera playerCamera;
    private LineRenderer bulletTrajectory;

    private Gun gunScript;
    private Health enemyToDamage;
    
    private float nextFire;
    public bool isReloading = false;

    private bool weapon1Active = true;
    private bool weapon2Active = false;
    
    public GameObject weapon1;
    public GameObject weapon2;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        bulletTrajectory = GetComponent<LineRenderer>();
        gunScript = GetComponentInChildren<Gun>();
        weapon1.SetActive(true);
        weapon2.SetActive(false);
    }

    void SwitchWeapon()
    {
        Debug.Log("Weapon Switched.");
        
        if (weapon1Active == true)
        {
            weapon1Active = false;
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            gunScript = GetComponentInChildren<Gun>();
            weapon2Active = true;
        }
        else if(weapon2Active == true)
        {
            weapon2Active = false;
            weapon2.SetActive(false);
            weapon1.SetActive(true);
            gunScript = GetComponentInChildren<Gun>();
            weapon1Active = true;
        }
    }


    void FixedUpdate()
    {
        if(isReloading)
        {
            return;
        }

        if (Input.GetButtonDown("Switch"))
        {
            SwitchWeapon();
        }
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (gunScript.currentAmmo <= 0)
            {
                StartCoroutine(gunScript.Reload());
                return;
            }
            
            nextFire = Time.time + gunScript.fireRate;
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            bulletTrajectory.SetPosition(0, gunScript.barrelTip.position);
            gunScript.currentAmmo--;
            gunScript.Shoot();
            
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunScript.range))
            {
                bulletTrajectory.SetPosition(1, hit.point);
                Debug.Log(hit.transform.name);
                 if (hit.transform.gameObject.tag == "Enemy")
                 {
                     enemyToDamage = hit.transform.gameObject.GetComponent<Health>();
                     enemyToDamage.TakeDamage(gunScript.damage);
                     //Destroy(hit.transform.gameObject);
                 }
            }
        }
        
        if (Input.GetButtonDown("Reload") && gunScript.currentAmmo < gunScript.fullAmmo)
        {
            StartCoroutine(gunScript.Reload());
            return;
        }
    }
}
