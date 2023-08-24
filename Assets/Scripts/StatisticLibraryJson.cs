using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticLibraryJson : MonoBehaviour
{
    public ParametersLibrary library { get; private set; }

    [SerializeField]
    private string pathJson;

    private void Awake()
    {
        library = JsonLoadAndRead.Load<ParametersLibrary>(pathJson);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        JsonLoadAndRead.Save(library, pathJson);
    }
}
