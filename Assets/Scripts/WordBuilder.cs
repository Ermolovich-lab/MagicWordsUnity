using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WordBuilder : MonoBehaviour
{
    public bool isWord = false;

    public bool isReset = true;

    public static WordBuilder instance;

    [HideInInspector]
    private StringBuilder word = new StringBuilder();

    public string Word { get => word.ToString(); }

    public float timeResetWord = 3;

    private float timer = 0;

    private WordLibrary wordLibrary;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        wordLibrary = WordLibraryJson.GetWordLibrary();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeResetWord && word.Length > 0)
        {
            isWord = FillField.instance.CheckWord(Word);

            word.Clear();
            isReset = true;
        }
        else if (isReset)
            isReset = false;

    }

    public void SetLetter(char letter)
    {
        timer = 0;
        word.Append(letter);
    }
}
