using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour
{
    public static Statistic instanse;

    public ParametersLibrary library { get; private set; }

    public Action<string, float> OnAction { get; set; }

    [SerializeField]
    private string pathJson;

    private void Awake()
    {
        library = JsonLoadAndRead.Load<ParametersLibrary>(pathJson);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instanse == null)
        {
            instanse = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStatistic(string name, float value)
    {
        var parameter = library.parameters.Find(x => x.name == name);
        parameter.value += value;

        OnAction?.Invoke(parameter.name, parameter.value);

        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        JsonLoadAndRead.Save(library, pathJson);
    }
}
