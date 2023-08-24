using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public string nameLevel;
    public string nameSection;

    public RectTransform preStartPanelRect;

    public GameObject panelPref;

    [HideInInspector]
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        WordLibraryJson.sectionLibrary.currNameLevel = nameLevel;
        WordLibraryJson.sectionLibrary.currNameSection = nameSection;

        button = GetComponent<Button>();

        button.interactable = WordLibraryJson.sectionLibrary.currLevel.unlocked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlocked(bool isUnlocked)
    {
        WordLibraryJson.sectionLibrary.currNameLevel = nameLevel;
        WordLibraryJson.sectionLibrary.currNameSection = nameSection;

        WordLibraryJson.sectionLibrary.currLevel.unlocked = isUnlocked;

        button.interactable = isUnlocked;
    }

    public void SetCurrLevel()
    {
        WordLibraryJson.sectionLibrary.currNameLevel = nameLevel;
        WordLibraryJson.sectionLibrary.currNameSection = nameSection;

        foreach (Transform child in preStartPanelRect.transform) Destroy(child.gameObject);

        var parentTransform = preStartPanelRect.GetComponent<RectTransform>();
        parentTransform.sizeDelta = new Vector2(parentTransform.sizeDelta.x, 0);

        var words = WordLibraryJson.sectionLibrary.currLevel.words;

        var settings = new UIFactory.UISettings(new Vector3(0, -200, 0), panelPref.GetComponent<RectTransform>().sizeDelta.y, -25, 25);

        UIFactory.ElementUIFactory(parentTransform, panelPref, words.Count, settings, (panel, i) =>
        {
            var word = panel.transform.GetChild(0);
            var translation = panel.transform.GetChild(1);

            word.GetComponent<TextMeshProUGUI>().text = words[i].value;
            translation.GetComponent<TextMeshProUGUI>().text = words[i].translation;

            parentTransform.sizeDelta = new Vector2(parentTransform.sizeDelta.x, parentTransform.sizeDelta.y + 450);
        });
    }
}
