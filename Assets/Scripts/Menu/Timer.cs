using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private float minutesToEnd = 2.0f;
    private int seconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        seconds = Mathf.FloorToInt(minutesToEnd * 60.0f);
        ViewTimeLeft();
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        yield return new WaitForSeconds(1.0f);
        seconds -= 1;
        if (seconds >= 0)
        {
            ViewTimeLeft();
            StartCoroutine(Tick());
        }
        else
        {
            GetComponent<LvlManager>().EndLVL();
        }
    }

    void ViewTimeLeft()
    {
        int mint = Mathf.FloorToInt(seconds / 60.0f);
        int sec = seconds % 60;

        if (sec < 10)
        {
            label.text = $"{mint}:0{sec}";
        }
        else
        {
            label.text = $"{mint}:{sec}";
        }
    }

}
