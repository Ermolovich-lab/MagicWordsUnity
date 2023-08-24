using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelObj
{
    public string name;
    public List<Word> words;
    public bool unlocked;

    //public string Value { get => value; }

    //public string Translation { get => translation; }

    public LevelObj(string name, List<Word> words, bool unlocked)
    {
        this.name = name;
        this.words = words;
        this.unlocked = unlocked;
    }
}
