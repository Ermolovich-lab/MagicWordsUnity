using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AdventuresModLevel : AbstractLevel
{
    private SectionLibrary sectionLibrary = WordLibraryJson.sectionLibrary;

    protected override void initWords()
    {  
        words = sectionLibrary.currLevel.words;
    }
}
