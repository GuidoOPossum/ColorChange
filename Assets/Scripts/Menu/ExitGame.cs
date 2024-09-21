using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitGame : MonoBehaviour , IPointerUpHandler
{
    private void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        QuitGame();
        
    }
}
