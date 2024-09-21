using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    [SerializeField] private Difficulty levelDifficulty;
    

    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();
        if (levelDifficulty == SettingsManager.instanse.difficulty){
            toggle.isOn = true;
        }
        toggle.onValueChanged.AddListener((bool isOn) => {SetDifficulty( isOn);});

    }
    public void SetDifficulty(bool isOn)
    {
        
        if (!isOn)
        {
            return;
        }

        SettingsManager.instanse.difficulty = levelDifficulty;
        //print(SettingsManager.instanse.difficulty);
    }
}
