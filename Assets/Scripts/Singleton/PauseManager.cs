using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;
    
    public bool isPaused
    {
        get
        {
            return _isPaused;
        }
    }
    private static PauseManager _instanse;
    public static PauseManager instanse
    {
        get
        {
            return _instanse;
        }
    }
    void Awake()
    {
        if (_instanse == null)
        {
            _instanse = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TogglePause()
    {
        if (_isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; 
        _isPaused = true;
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;  
        _isPaused = false;
        
    }
}
