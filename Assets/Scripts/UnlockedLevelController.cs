using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedLevelController : MonoBehaviour
{
    public static UnlockedLevelController instance;

    private static List<LevelObj> levelObjs;
    private int currLastUnlockedLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        levelObjs = new List<LevelObj>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear()
    {
        levelObjs.Clear();
    }

    public void AddLevelObj(LevelObj levelObj)
    {
        levelObjs.Add(levelObj);

        if (levelObj.unlocked)
        {
            currLastUnlockedLevel = levelObjs.Count - 1;
        }
    }

    public void UnlockedNextLevel()
    {
        levelObjs[++currLastUnlockedLevel].unlocked = true;
    }
}
