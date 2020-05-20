using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{    
    public static float score;
    public float currentScore;

    public float boids;
    
    void Start()
    {
        score = 0;
        boids = 0;
    }

    private void Update()
    {
        currentScore = score;
    }

    public void AddPoints(float points)
    {
        score += points;
    }
}
