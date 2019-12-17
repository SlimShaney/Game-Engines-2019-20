using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretsFire : MonoBehaviour
{
    private Camera playerCamera;
    private LineRenderer bulletTrajectory;

    private Gun leftTurretGunScript;
    private Gun rightTurretGunScript;
    private Health enemyToDamage;
    
    private float nextFire;
    public bool isReloading = false;
    
    public GameObject[] turrets;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        bulletTrajectory = GetComponent<LineRenderer>();
        leftTurretGunScript = turrets[0].GetComponent<Gun>();
        rightTurretGunScript = turrets[1].GetComponent<Gun>();
    }



    void FixedUpdate()
    {
        if(isReloading)
        {
            return;
        }

        if (Input.GetButtonDown("Switch"))
        {
            
        }
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (leftTurretGunScript.currentAmmo <= 0)
            {
                StartCoroutine(leftTurretGunScript.Reload());
                return;
            }
            
            nextFire = Time.time + leftTurretGunScript.fireRate;
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            bulletTrajectory.SetPosition(0, leftTurretGunScript.barrelTip.position);
            leftTurretGunScript.currentAmmo--;
            leftTurretGunScript.Shoot();
            
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, leftTurretGunScript.range))
            {
                bulletTrajectory.SetPosition(1, hit.point);
                Debug.Log(hit.transform.name);
                 if (hit.transform.gameObject.CompareTag("Enemy"))
                 {
                     enemyToDamage = hit.transform.gameObject.GetComponent<Health>();
                     enemyToDamage.TakeDamage(leftTurretGunScript.damage);
                     //Destroy(hit.transform.gameObject);
                 }
            }
        }
        
        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            if (rightTurretGunScript.currentAmmo <= 0)
            {
                StartCoroutine(rightTurretGunScript.Reload());
                return;
            }
            
            nextFire = Time.time + rightTurretGunScript.fireRate;
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            bulletTrajectory.SetPosition(0, rightTurretGunScript.barrelTip.position);
            rightTurretGunScript.currentAmmo--;
            rightTurretGunScript.Shoot();
            
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, rightTurretGunScript.range))
            {
                bulletTrajectory.SetPosition(1, hit.point);
                Debug.Log(hit.transform.name);
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    enemyToDamage = hit.transform.gameObject.GetComponent<Health>();
                    enemyToDamage.TakeDamage(rightTurretGunScript.damage);
                    //Destroy(hit.transform.gameObject);
                }
            }
        }
        
        if (Input.GetButtonDown("Reload") && leftTurretGunScript.currentAmmo < leftTurretGunScript.fullAmmo)
        {
            StartCoroutine(leftTurretGunScript.Reload());
            StartCoroutine(rightTurretGunScript.Reload());
            return;
        }
    }
}