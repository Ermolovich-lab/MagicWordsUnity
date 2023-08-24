using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordLibraryJson : MonoBehaviour
{
    public static SectionLibrary sectionLibrary;

    private void Awake()
    {
        if (sectionLibrary == null)
            sectionLibrary = JsonLoadAndRead.Load<SectionLibrary>("Save.json");
    }

    public static WordLibrary GetWordLibrary() 
    {
        var wordLibrary = new WordLibrary();

        if (sectionLibrary.sections != null || sectionLibrary != null)
        {
            foreach (var section in sectionLibrary.sections)
            {
                foreach (var level in section.levels)
                {
                    wordLibrary.words.AddRange(level.words);
                }
            }
        }

        return wordLibrary;
    }

    //private void Awake()
    //{
    //    wordLibrary = new WordLibrary();
    //    Create();
    //}

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        JsonLoadAndRead.Save(sectionLibrary, "Save.json");
    }

    //public static void Create()
    //{
    //    string path = "D:/words.txt";
    //    string pathT = "D:/translations.txt";

    //    using (StreamReader readerT = new StreamReader(pathT))
    //    {
    //        using (StreamReader reader = new StreamReader(path))
    //        {
    //            string line;
    //            string lineT;

    //            while ((line = reader.ReadLine()) != null)
    //            {
    //                lineT = readerT.ReadLine();
    //                if (line.Length <= 16 && line.IndexOf(" ") == -1)
    //                {
    //                    wordLibrary.words.Add(new Word(line, lineT, false));
    //                }
    //            }
    //        }
    //    }
    //}
}
