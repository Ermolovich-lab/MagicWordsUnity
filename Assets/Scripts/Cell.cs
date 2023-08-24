using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour, IPressed, IReset
{
    public bool isCanPressed = true;

    public GameObject textObj;

    private TextMeshProUGUI text;

    public TextMeshProUGUI Text { get => text; }

    public bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        text = textObj.GetComponent<TextMeshProUGUI>();
        FillField.instance.SubscribeToCell(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (WordBuilder.instance.isReset)
        {
            if (isPressed && WordBuilder.instance.isWord)
                isCanPressed = false;

            isPressed = false;
        }
    }

    public void SendLetter()
    {
        if (!isPressed && isCanPressed)
        {
            WordBuilder.instance.SetLetter(text.text[0]);
            isPressed = true;
        }
    }

    public void Press()
    {
        SendLetter();
    }

    public void ResetObj()
    {
        isCanPressed = true;
        isPressed = false;
    }
}
