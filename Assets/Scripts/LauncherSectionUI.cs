using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LauncherSectionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject panelPref;
    [SerializeField]
    private GameObject levelPref;
    [SerializeField]
    private GameObject panelHeaderPref;
    [SerializeField]
    private GameObject cetionInfoPref;
    [SerializeField]
    private GameObject parent;

    private RectTransform rectTransformParent;

    private SectionLibrary sectionLibrary;

    [SerializeField]
    private LevelMap levelMap;

    [SerializeField]
    private float marginLevel;

    // Start is called before the first frame update
    void Start()
    {
        sectionLibrary = WordLibraryJson.sectionLibrary;
        rectTransformParent = parent.GetComponent<RectTransform>();
        SectionFactory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SectionFactory()
    {
        UnlockedLevelController.instance.Clear();

        float deltaPositionSection = 0;
        float positionSection = 0;
        float sizeLevel = levelPref.GetComponent<RectTransform>().rect.size.y;

        float fullSizeOffset = marginLevel * 2;
        float startAndEndLevelOffset = (fullSizeOffset + sizeLevel);
        float betweenLevelsOffset = (sizeLevel / 2 + fullSizeOffset);

        float beginOffset = 200;

        foreach (var section in sectionLibrary.sections)
        {
            float sizeSectionPanel = (betweenLevelsOffset * (section.levels.Count - 1)) + startAndEndLevelOffset;
            float startPositionUIElement = -((startAndEndLevelOffset + beginOffset) / 2);

            deltaPositionSection = sizeSectionPanel / 2;
            positionSection -= deltaPositionSection;

            var sectionSettings = new UIFactory.UISettings(new Vector3(0, positionSection, 0), sizeSectionPanel, 0, fullSizeOffset);

            UIFactory.ElementUIFactory(rectTransformParent, panelPref, 1, sectionSettings, (panel, i) =>
            {
                var backgeoundImage = panel.GetComponent<UnityEngine.UI.Image>();
                backgeoundImage.sprite = LoadImage.GetImage("BackgroundSection\\" + section.name);

                var rectTransformSectionPanel = panel.GetComponent<RectTransform>();
                rectTransformSectionPanel.sizeDelta = new Vector2(rectTransformSectionPanel.sizeDelta.x, sizeSectionPanel);

                var levelSettings = new UIFactory.UISettings(new Vector3(0, startPositionUIElement, 0), sizeLevel, deltaPositionSection, fullSizeOffset);
                var sectionInfoSettings = new UIFactory.UISettings(new Vector3(350, startPositionUIElement, 0), 0, deltaPositionSection, 0);
                var sectionHeaderSettings = new UIFactory.UISettings(new Vector3(0, -100, 0), 0, deltaPositionSection, 0);

                UIFactory.ElementUIFactory(rectTransformSectionPanel, panelHeaderPref, 1, sectionHeaderSettings, (button, i) =>
                {
                    button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = section.name;
                });

                UIFactory.ElementUIFactory(rectTransformSectionPanel, cetionInfoPref, 1, sectionInfoSettings, (button, i) =>
                {
                    button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => levelMap.SetActiveSectionInfoPanel());
                    button.GetComponent<SectionInfoButton>().nameSection = section.name;
                });

                UIFactory.ElementUIFactory(rectTransformSectionPanel, levelPref, section.levels.Count, levelSettings, (button, i) =>
                {
                    var levelButton = button.GetComponent<LevelButton>();

                    levelButton.nameLevel = section.levels[i].name;
                    levelButton.nameSection = section.name;
                    levelButton.preStartPanelRect = levelMap.preStartPanelRect;
                    levelButton.panelPref = levelMap.panelPref;
                    button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => levelMap.SetActivePreStartPanel());
                    button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = section.levels[i].name;

                    UnlockedLevelController.instance.AddLevelObj(section.levels[i]);
                });

                rectTransformParent.sizeDelta = new Vector2(rectTransformParent.sizeDelta.x, rectTransformParent.sizeDelta.y + sizeSectionPanel);
            });
        }

        rectTransformParent.position = new Vector3(rectTransformParent.position.x, -rectTransformParent.sizeDelta.y / 2, rectTransformParent.position.z);
    }
}
