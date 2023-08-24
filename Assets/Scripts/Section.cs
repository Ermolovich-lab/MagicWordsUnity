using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Section
{
    public string name;
    public string info;
    public List<LevelObj> levels;

    //public string Value { get => value; }

    //public string Translation { get => translation; }

    public Section(string name, string info, List<LevelObj> levels)
    {
        this.name = name;
        this.info = info;
        this.levels = levels;
    }
}
