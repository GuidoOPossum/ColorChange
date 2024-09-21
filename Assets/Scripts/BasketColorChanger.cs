using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketColorChanger : MonoBehaviour
{
    [SerializeField] float waitTime = 1.0f;
    [SerializeField] SpriteRenderer sprite;
    private ColorPalette[] palette;
    public ColorPalette currentColor = ColorPalette.White;
    // Start is called before the first frame update
    void Start()
    {
        palette = ColorInfo.palette.Keys.ToArray();
        StartCoroutine(ChangeColor());
        sprite.color = ColorInfo.palette[currentColor];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(waitTime);
        
        int randomIndex = UnityEngine.Random.Range(0, palette.Length);
        currentColor = palette[randomIndex];
        sprite.color = ColorInfo.palette[currentColor];
        StartCoroutine(ChangeColor());
    }
    

}


