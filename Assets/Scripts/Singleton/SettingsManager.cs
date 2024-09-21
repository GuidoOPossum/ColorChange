using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public Difficulty difficulty = Difficulty.Easy;
    private static SettingsManager _instanse;
    public static SettingsManager instanse
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
}

public enum Difficulty 
{
    Easy,
    Medium,
    Hard
}