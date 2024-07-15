
using Unity.VisualScripting;

public static class Language
{
    public enum Options
    {
        EN, RU, AM
    }

    public static Language.Options ToLanguage(this string lang)
    {
        switch (lang)
        {
            case "en":
                return Options.EN;
            case "ru":
                return  Options.RU;
            case "am":
                return  Options.AM;
        }

        return Options.EN;
    }
}
