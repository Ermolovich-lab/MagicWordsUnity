using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject panelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(string pathImage, string headerText)
    {
        StartCoroutine(ChowCoroutine(pathImage, headerText));
    }

    IEnumerator ChowCoroutine(string pathImage, string headerText)
    {
        var parent = GameObject.FindWithTag("MainCanvas").GetComponent<RectTransform>();
        var panel = Instantiate(panelPrefab, parent);

        var image = panel.transform.GetChild(0);
        var header = panel.transform.GetChild(1);
        //var main = panel.transform.GetChild(2);

        header.GetComponent<TextMeshProUGUI>().text = headerText;
        //main.GetComponent<TextMeshProUGUI>().text = mainText;
        image.GetComponent<Image>().sprite = LoadImage.GetImage("AchievementImages\\" + pathImage);

        yield return new WaitForSeconds(4);

        Destroy(panel);
    }
}
