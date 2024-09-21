using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject pauseLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        PauseManager pauseManager = PauseManager.instanse;
        pauseManager.TogglePause();
        menu.SetActive(pauseManager.isPaused);
        pauseLabel.SetActive(pauseManager.isPaused);
    }
}
