using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreLabel(ScoreManager.instanse.currentScore);
        ScoreManager.instanse.updateScore += UpdateScoreLabel;
    }

    // Update is called once per frame
    void UpdateScoreLabel(int currentScore)
    {
        scoreText.text = $"Score : {currentScore}";
    }

    private void OnDestroy()
    {
        ScoreManager.instanse.updateScore -= UpdateScoreLabel;
    }
}
