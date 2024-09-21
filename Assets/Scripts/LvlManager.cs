using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private TextMeshProUGUI endgameLabel;
    [SerializeField] private Button pauseButton;

    void Start()
    {
        ScoreManager.instanse.Restart();
    }

    public void EndLVL()
    {
        PauseManager.instanse.PauseGame();
        pauseButton.interactable = false;
        menu.SetActive(true);
        
        ScoreManager scoreManager = ScoreManager.instanse;
        if (scoreManager.maxScore < scoreManager.currentScore)
        {
            scoreManager.SaveRecord();
            endgameLabel.text = $"Score : {scoreManager.currentScore} \n New record!!!";
        }
        else
        {
            endgameLabel.text = $"Score : {scoreManager.currentScore}";
        }
        endgameLabel.gameObject.SetActive(true);
    }
}
