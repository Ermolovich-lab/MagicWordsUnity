using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SectionLibrary
{
    public string currNameSection = "One";

    public string currNameLevel = "One";

    public List<Section> sections = new List<Section>();

    public LevelObj currLevel { get => sections.Find(x => x.name == currNameSection).levels.Find(x => x.name == currNameLevel); }

    public Section currSection { get => sections.Find(x => x.name == currNameSection); }
}
