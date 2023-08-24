using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SectionInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo()
    {
        textMesh.text = WordLibraryJson.sectionLibrary.currSection.info;
    }
}
