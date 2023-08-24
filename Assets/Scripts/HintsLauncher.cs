using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintsLauncher : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    [SerializeField]
    private Animator animator;

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpen) return;

        textMesh.text = "";
        foreach (var word in FillField.instance.usedWords)
        {
            //if(!word.isUse)
                textMesh.text += word.translation + "\n\n";
        }
    }

    public void Close()
    {
        animator.SetTrigger("close");
        isOpen = false;
        Invoke("Deactivate", 0.5f);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("open");
        isOpen = true;
    }

    public void OpenForWhile(float time)
    {
        Open();

        Invoke("Close", time);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void OpenAndClose()
    {
        if (isOpen)
        {
            Close();
            isOpen = false;
        }
        else
        {
            Open();
            isOpen = true;
        }
    }
}
