using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage
{

    public static Sprite GetImage(string path)
    {
        var background = Resources.Load<Sprite>(path);

        return background;
    }
}
