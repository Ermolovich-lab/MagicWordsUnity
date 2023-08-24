using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInfoButton : MonoBehaviour
{
    public string nameSection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrSection()
    {
        WordLibraryJson.sectionLibrary.currNameSection = nameSection;
    }
}
