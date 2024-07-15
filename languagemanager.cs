using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static readonly string ACTION = "SELECTED_LANG";
    private static string SELECTED_LANG = "selected_lang";
    private Dictionary<string, string> translations;
    void Start()
    {

        var lang = PlayerPrefs.GetString(SELECTED_LANG, "en").ToLanguage();
       
        GetLanguage(lang);

        EventBus.Register<Language.Options>(LanguageClick.ACTION, ChangeLanguage);

        EventBus.Trigger(ACTION, new ChangeTranslations { language = lang, translations = translations});
    }

    private void ChangeLanguage(Language.Options language)
    {
        PlayerPrefs.SetString(SELECTED_LANG, language.ToString());
        PlayerPrefs.Save();
        GetLanguage(language);
    }

    private void GetLanguage(Language.Options language)
    {
        translations = ReadFromJson.LoadTranslatins(language);
    }

   public struct ChangeTranslations
    {
        public Language.Options language;
        public Dictionary<string, string> translations;
    }
}
