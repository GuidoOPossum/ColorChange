using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorPalette
{
    White,
    Red,
    Green,
    Blue
}

public class ColorInfo
{
    static public Dictionary<ColorPalette, Color> palette = new Dictionary<ColorPalette, Color>(){
        {ColorPalette.White , Color.white},
        {ColorPalette.Red , Color.red},
        {ColorPalette.Green , Color.green},
        //{ColorPalette.Blue , Color.blue}
    };
}