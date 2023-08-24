using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    public GameObject preStartPanel;
    public GameObject sectionInfoPanel;
    public RectTransform preStartPanelRect;
    public GameObject panelPref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        NextSceneManager.instance.LoadLevelScene("Menu");
    }

    public void SetActivePreStartPanel()
    {
        preStartPanel.SetActive(true);
    }

    public void SetActiveSectionInfoPanel()
    {
        sectionInfoPanel.SetActive(true);
        sectionInfoPanel.transform.GetChild(0).GetComponent<SectionInfo>().UpdateInfo();
    }

    public void StartGame()
    {
        NextSceneManager.instance.LoadLevelScene("AdventuresModGame");
    }
}
