using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore = 0;
    public int currentScore {get{return _currentScore;}}
    private int _maxScore = 0;
    public int maxScore{get{return _maxScore;}}
    public Action<int> updateScore;
    private static ScoreManager _instanse;
    public static ScoreManager instanse
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

    void Start()
    {
        _maxScore = PlayerPrefs.GetInt("score", 0);
    }
    public void AddToScore(int i){
        _currentScore += i;
        // коли скор нижче нуля це пригнічує
        if (_currentScore <= 0)
        {
            _currentScore = 0;
        }
        updateScore?.Invoke(_currentScore);
        
    }
    public void SaveRecord()
    {
        _maxScore = currentScore;
        PlayerPrefs.SetInt("score", _maxScore);
        PlayerPrefs.Save();
    }
    public void Restart()
    {
        _currentScore = 0;
    }
}
