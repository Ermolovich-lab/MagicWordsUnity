using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementsController : MonoBehaviour
{
    [SerializeField]
    private AchievementsLauncher launcher;

    public AchievementsLibrary library { get; private set; }

    [SerializeField]
    private string pathJson;

    void Awake()
    {
        library = JsonLoadAndRead.Load<AchievementsLibrary>(pathJson);
    }

    // Start is called before the first frame update
    void Start()
    {
        Statistic.instanse.OnAction += UpdateAchievements;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Achievement> GetIsDoneAchievements()
    {
        return library.achievements.Where(x => x.isDone).ToList();
    }

    public void UpdateAchievements(string name, float value)
    {
        var achievements = library.achievements.Where(x => x.nameParameter == name);

        foreach (var achievement in achievements)
        {
            if (!achievement.isDone && value >= achievement.requiredValue)
            {
                achievement.isDone = true;
                launcher.Show(achievement.pathImage, achievement.headerText);
            }
        }

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
