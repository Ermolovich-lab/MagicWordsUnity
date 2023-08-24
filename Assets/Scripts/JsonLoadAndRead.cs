using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonLoadAndRead : MonoBehaviour
{
    public static T Load<T>(string path)
    {
        if (File.Exists(Application.dataPath + "/" + path))
            return JsonUtility.FromJson<T>(File.ReadAllText(Application.dataPath + "/" + path));
        else
            return default(T);

        //throw new System.Exception(Application.dataPath);    
    }

    public static void Save(object obj, string path)
    {
        File.WriteAllText(Application.dataPath + "/" + path, JsonUtility.ToJson(obj));
    }
}
