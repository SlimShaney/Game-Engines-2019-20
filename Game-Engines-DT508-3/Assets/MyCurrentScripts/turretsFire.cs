﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretsFire : MonoBehaviour
{
    private Camera playerCamera;
    private LineRenderer bulletTrajectory;

    private Gun leftTurretGunScript;
    private Gun rightTurretGunScript;
    
    private Health enemyToDamage;
    
    private float leftTurretNextFire;
    private float rightTurretNextFire;
    //public bool isReloading = false;

    public GameObject defaultDirectionObject;
    
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
        
        
        if (Input.GetButton("Fire1") && Time.time > leftTurretNextFire)
        {
            if(leftTurretGunScript.isReloading)
            {
                return;
            }
            if (leftTurretGunScript.currentAmmo <= 1)
            {
                StartCoroutine(leftTurretGunScript.Reload());
                //return;
            }
            
            leftTurretNextFire = Time.time + leftTurretGunScript.fireRate;
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            bulletTrajectory.SetPosition(0, leftTurretGunScript.barrelTip.position);
            leftTurretGunScript.currentAmmo--;
            leftTurretGunScript.Shoot();
            
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, leftTurretGunScript.range))
            {
                bulletTrajectory.SetPosition(1, hit.point);
                //Debug.Log(hit.transform.name);
                 if (hit.transform.gameObject.CompareTag("Player"))
                 {
                     enemyToDamage = hit.transform.gameObject.GetComponent<Health>();
                     enemyToDamage.TakeDamage(leftTurretGunScript.damage);
                 }
                 else
                 {
                     //bulletTrajectory.SetPosition(1, defaultDirectionObject.transform.position);
                 }
            }
        }
        
        if (Input.GetButton("Fire2") && Time.time > rightTurretNextFire)
        {
            if(rightTurretGunScript.isReloading)
            {
                return;
            }
            if (rightTurretGunScript.currentAmmo <= 1)
            {
                StartCoroutine(rightTurretGunScript.Reload());
                //return;
            }
            
            rightTurretNextFire = Time.time + rightTurretGunScript.fireRate;
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            bulletTrajectory.SetPosition(0, rightTurretGunScript.barrelTip.position);
            rightTurretGunScript.currentAmmo--;
            rightTurretGunScript.Shoot();
            
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, rightTurretGunScript.range))
            {
                //bulletTrajectory.SetPosition(1, hit.point);
                //Debug.Log(hit.transform.name);
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    bulletTrajectory.SetPosition(1, hit.point);
                    enemyToDamage = hit.transform.gameObject.GetComponent<Health>();
                    enemyToDamage.TakeDamage(rightTurretGunScript.damage);
                    return;
                }
                    //bulletTrajectory.SetPosition(1, defaultDirectionObject.transform.position);
            }
        }
        
        if (Input.GetButtonDown("Reload") && (leftTurretGunScript.currentAmmo < leftTurretGunScript.fullAmmo 
            || rightTurretGunScript.currentAmmo < rightTurretGunScript.fullAmmo))
        {
            StartCoroutine(leftTurretGunScript.Reload());
            StartCoroutine(rightTurretGunScript.Reload());
            return;
        }
    }
}