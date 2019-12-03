using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TMP_Text ammoCount;
    public TMP_Text currentHealth;
    
    private Gun gunDetails;
    private Health health;
    
    void Start()
    {
        gunDetails = GetComponentInChildren<Gun>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        gunDetails = GetComponentInChildren<Gun>();
        ammoCount.text = gunDetails.currentAmmo + "/" + gunDetails.fullAmmo;
        currentHealth.text = "Hull Integrity: " + health.currentHealth + "%";
    }
}
