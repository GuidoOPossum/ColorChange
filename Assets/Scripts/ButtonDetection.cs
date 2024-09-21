using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class ButtonDetection : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Action onInputDown;
    public Action onInputUp;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        onInputDown?.Invoke();


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onInputUp?.Invoke();

    }
}