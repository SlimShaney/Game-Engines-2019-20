using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TMP_Text currentHealth;
    public TMP_Text currentScore;
    
    private Health health;
    private Score score;
    
    void Start()
    {
        health = GetComponent<Health>();
        score = GetComponentInChildren<Score>();
    }

    void Update()
    {
        currentHealth.text = "Hull Integrity: " + health.currentHealth + "%";
        currentScore.text = "Total Score: " + score.currentScore;
    }
}
