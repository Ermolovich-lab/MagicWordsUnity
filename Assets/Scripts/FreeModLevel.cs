using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FreeModLevel : AbstractLevel
{
    private WordLibrary wordLibrary = WordLibraryJson.GetWordLibrary();

    protected override void initWords()
    {
        words = wordLibrary.words;
    }
}
