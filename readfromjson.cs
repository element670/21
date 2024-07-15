using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFromJson : MonoBehaviour
{


    public static Dictionary<string, string> LoadTranslatins(Language.Options language)
    {
        string postfix = "en";
        switch (language)
        {
            case Language.Options.EN:
                postfix = "en";
                break;
            case Language.Options.RU:
                postfix = "ru";
                break;
            case Language.Options.AM:
                postfix = "am";
                break;
        }

        string fileName = $"Assets/Json/language_{postfix}.json";
        string jsonstr = File.ReadAllText(fileName);
        return JsonUtility.FromJson<Languages>(jsonstr).languages;
    }


    [System.Serializable]
    public class Languages
    {
        public Dictionary<string, string> languages;

    }
}
