using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScoreLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreLabel(ScoreManager.instanse.maxScore);
    }

    void UpdateScoreLabel(int currentScore)
    {
        scoreText.text = $"Max Score : {currentScore}";
    }
}
