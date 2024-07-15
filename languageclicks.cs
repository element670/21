using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LanguageClick : MonoBehaviour
{
    public static readonly string ACTION = "LANGUAGE_CLICK";
    [SerializeField] 
    private Language.Options language;
    [SerializeField]
    private Toggle button;

    private void Awake()
    {
        button.onValueChanged.RemoveAllListeners();
        button.onValueChanged.AddListener((isCheked) => { 
            if (isCheked)
            {
                EventBus.Trigger(ACTION, language);
                print(language + " is selected");
            }
        });
    }
    public Language.Options GetLanguage() => language;

    public void Toggle()
    {
        button.isOn = true;
    }
}
