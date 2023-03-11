using UnityEngine.UI;
using UnityEngine;

public class LanguageText : MonoBehaviour
{
    public int language;
    public string[] text;
    private Text textLine;

    void Start()
    {
        language = PlayerPrefs.GetInt("language", language);
        textLine = GetComponent<Text>();
        textLine.text = "" + text[language];
    }
}
