using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Icons;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private LanguageClick en;
    [SerializeField]
    private LanguageClick ru;
    [SerializeField]
    private LanguageClick am;
    private void Awake()
    {
        closeButton.onClick.AddListener(() => {
            Show(false);
        });
        EventBus.Register<LanguageManager.ChangeTranslations>(LanguageManager.ACTION, SetSelectedLanguage);


    }
    public void Show(bool show)
    {
        gameObject.SetActive(false);
    }

    private void SetSelectedLanguage(LanguageManager.ChangeTranslations translation)
    {
       
        if(en.GetLanguage() == translation.language) 
        { 
            en.Toggle();
        }
        if(ru.GetLanguage() == translation.language)
        {
            ru.Toggle();
        }
        if (am.GetLanguage() == translation.language)
        {
            am.Toggle();
        }
        
        translation.translations.TryGetValue("language_title", out var value);
        //tv.text = value;
    }
}
