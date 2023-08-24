using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class FillField : MonoBehaviour
{
    public static FillField instance;

    public List<Word> usedWords = new List<Word>();
    public int notUsedWords = 0;
    public int usedWordsCount = 0;
    public int freeWorldCount = 0;
    private List<Word> freeWords = new List<Word>();

    public bool isFieldFull = false;

    private char[] Alphabet = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    private List<Cell> cells = new List<Cell>();

    public Action<bool> OnCheckWord;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckWord(string word)
    {
        Word checkWord = null;

        foreach (var useWord in usedWords)
        {
            if (useWord.value.Equals(word))
            {
                checkWord = useWord;
                OnCheckWord?.Invoke(true);
            }
        }

        if (checkWord != null)
        {
            checkWord.isUse = true;
            notUsedWords--;
            isFieldFull = CheckAllWordUsed();
            usedWords.Remove(checkWord);

            return true;
        }

        OnCheckWord?.Invoke(false);

        return false;
    }

    private bool CheckAllWordUsed()
    {
        foreach(var word in usedWords)
        {
            if (!word.isUse)
            {
                return false;
            }
        }

        return true;
    }

    private void ResetCell()
    {
        foreach (var cell in cells)
        {
            cell.ResetObj();
        }
    }

    public void SubscribeToCell(Cell cell)
    {
        cells.Add(cell);
    }

    public void SetWords(List<Word> words)
    {
        freeWords.Clear();
        freeWords.AddRange(words);
    }

    public void Fill()
    {
        freeWords.AddRange(usedWords);
        usedWords.Clear();
        StringBuilder approvedWords = new StringBuilder();
        while (freeWords.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, freeWords.Count);
            var word = freeWords[index];
            if (word.value.Length + approvedWords.Length <= cells.Count)
            {
                //if (!word.isUse)
                //{
                    usedWords.Add(word);
                    Debug.Log(word.value);
                    approvedWords.Append(word.value);
                    freeWords.RemoveAt(index);
                //}
            }
            else
                break;
        }

        freeWorldCount = freeWords.Count;
        notUsedWords = usedWords.Count;
        usedWordsCount = usedWords.Count;

        while (approvedWords.Length < cells.Count)
        {
            approvedWords.Append(Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)]);
        }

        List<Cell> freeCells = new List<Cell> ();
        freeCells.AddRange(cells);

        for (int i = 0; i < cells.Count; i++)
        {
            int index = UnityEngine.Random.Range(0, freeCells.Count);
            freeCells[index].Text.text = approvedWords[i].ToString();
            freeCells.RemoveAt(index);
        }

        ResetCell();
    }
}
