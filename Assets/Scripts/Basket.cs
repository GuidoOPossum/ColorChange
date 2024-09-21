using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private ButtonDetection detection;
    private bool draged = false;
    private float offset_x = 0.0f;
    private BasketColorChanger basketColor;
    [SerializeField] private float speed = 5.0f;
    void Start()
    {
        basketColor = GetComponent<BasketColorChanger>();
        detection.onInputDown += PointerDown;
        detection.onInputUp += PointerUp;
    }

    void FixedUpdate()
    {
        if (!draged) return;
        
        Vector2 mousePos = GetInputPos();
        Vector2 targetPos = new Vector2(mousePos.x + offset_x, transform.position.y);
        Vector2 newPos = Vector2.MoveTowards(transform.position , targetPos, Time.fixedDeltaTime * speed);
        transform.position = newPos;
    }
    
    // для скріна теж має робити
    private Vector2 GetInputPos()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    } 
    public void PointerDown()
    {
        Vector2 inputPos = GetInputPos();
        offset_x = transform.position.x - inputPos.x ;
        draged = true;
    }
    public void PointerUp()
    {
        draged = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("Detect");
        
        FallingShapes fallingShape = other.gameObject.GetComponent<FallingShapes>();
        int shapeValue = 1;
        if (fallingShape.currentColor == basketColor.currentColor)
        {
            ScoreManager.instanse.AddToScore(shapeValue);
            SoundManager.instanse.CollectShape(true);
        }
        else
        {
            ScoreManager.instanse.AddToScore(-shapeValue);
            SoundManager.instanse.CollectShape(false);
        }
        fallingShape.Disapear();
        
        //Destroy(other.gameObject);
    }
}
