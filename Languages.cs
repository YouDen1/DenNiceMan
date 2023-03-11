using UnityEngine;
using UnityEngine.SceneManagement;

public class Languages : MonoBehaviour
{
    public int language;

    public void EnglishLanguage()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

    public void RussianLanguage()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

    public void UkrainianLanguage()
    {
        language = 2;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

    public void PolishLanguage()
    {
        language = 3;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }
}
