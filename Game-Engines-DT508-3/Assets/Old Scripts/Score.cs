using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public static float score;

    [SerializeField] public Text currentScore;
    public Text currentRound;
    
    void Start()
    {
        score = 0;        
    }

    void Update()
    {
        currentScore.text = "SCORE: " + score.ToString();
        currentRound.text = "ROUND: " + EnemySpawn.round.ToString();
    }
}
