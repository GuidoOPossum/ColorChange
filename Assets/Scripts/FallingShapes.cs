using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingShapes : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator anim;
    public ColorPalette currentColor = ColorPalette.White;
    private Rigidbody2D rb;

    void Start()
    {
        //sprite.color = ColorInfo.palette[currentColor];
        rb = GetComponent<Rigidbody2D>();
    }

    public void MultiplySpeed(float x)
    {
        speed = speed * x;
    }
    void FixedUpdate()
    {
        Vector2 movement = Vector2.down * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
    public void SetColor(ColorPalette newColor)
    {
        currentColor = newColor;
        sprite.color = ColorInfo.palette[currentColor];
    }

    public void Disapear()
    {
        anim.SetTrigger("Disapear");
    }
    public void QuitFree()
    {
        Destroy(gameObject);
    }
}
