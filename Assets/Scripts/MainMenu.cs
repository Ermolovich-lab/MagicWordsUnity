using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static LauncherSectionUI;

public class MainMenu : MonoBehaviour
{
    public WordLibrary wordLibrary;
    public AchievementsController achievements;

    [SerializeField]
    private GameObject prefAchievementPanel;
    [SerializeField]
    private RectTransform parentAchievementPanel;

    [SerializeField]
    private GameObject prefDictionaryPanel;
    [SerializeField]
    private RectTransform parentDictionaryPanel;

    // Start is called before the first frame update
    void Start()
    {
        wordLibrary = WordLibraryJson.GetWordLibrary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FreeMode()
    {
        NextSceneManager.instance.LoadLevelScene("FreeModGame");
    }

    public void Levels()
    {
        NextSceneManager.instance.LoadLevelScene("Levels");
    }

    public void Dictionary()
    {
        foreach (Transform child in parentDictionaryPanel.transform) Destroy(child.gameObject);

        var parentTransform = parentDictionaryPanel.GetComponent<RectTransform>();
        parentTransform.sizeDelta = new Vector2(parentTransform.sizeDelta.x, 0);

        var words = wordLibrary.words;

        var settings = new UIFactory.UISettings(new Vector3(0, -200, 0), prefDictionaryPanel.GetComponent<RectTransform>().sizeDelta.y, -25, 25);

        UIFactory.ElementUIFactory(parentTransform, prefDictionaryPanel, words.Count, settings, (panel, i) =>
        {
            var isUde = panel.transform.GetChild(0);
            var word = panel.transform.GetChild(1);
            var translation = panel.transform.GetChild(2);

            isUde.GetComponent<TextMeshProUGUI>().text = words[i].isUse ? "Discovered" : "Not discovered yet";
            word.GetComponent<TextMeshProUGUI>().text = words[i].value;
            translation.GetComponent<TextMeshProUGUI>().text = words[i].translation;

            parentTransform.sizeDelta = new Vector2(parentTransform.sizeDelta.x, parentTransform.sizeDelta.y + 450);
        });

        parentTransform.position = new Vector3(parentTransform.position.x, -parentTransform.sizeDelta.y / 2, parentTransform.position.z);
    }

    public void Achievements()
    {
        foreach (Transform child in parentAchievementPanel.transform) Destroy(child.gameObject);

        var parentTransform = parentAchievementPanel.GetComponent<RectTransform>();
        parentTransform.sizeDelta = new Vector2(parentTransform.sizeDelta.x, 0);

        var isDoneAchievements = achievements.GetIsDoneAchievements();

        var settings = new UIFactory.UISettings(new Vector3(0, -200, 0), prefAchievementPanel.GetComponent<RectTransform>().sizeDelta.y, -25, 25);

        UIFactory.ElementUIFactory(parentTransform, prefAchievementPanel, isDoneAchievements.Count, settings, (panel, i) =>
        {
            var image = panel.transform.GetChild(0);
            var header = panel.transform.GetChild(1);
            var main = panel.transform.GetChild(2);

            header.GetComponent<TextMeshProUGUI>().text = isDoneAchievements[i].headerText;
            main.GetComponent<TextMeshProUGUI>().text = isDoneAchievements[i].mainText;
            image.GetComponent<Image>().sprite = LoadImage.GetImage("AchievementImages\\" + isDoneAchievements[i].pathImage);

            parentTransform.sizeDelta = new Vector2(parentTransform.sizeDelta.x, parentTransform.sizeDelta.y + 450);
        });

        parentTransform.position = new Vector3(parentTransform.position.x, -parentTransform.sizeDelta.y / 2, parentTransform.position.z);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
