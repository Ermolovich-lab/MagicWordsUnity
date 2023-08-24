using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Word
{
    public string value;
    public string translation;
    public bool isUse;

    //public string Value { get => value; }

    //public string Translation { get => translation; }

    public Word(string value, string translation, bool isUse)
    {
        this.value = value;
        this.translation = translation;
        this.isUse = isUse;
    }
}
