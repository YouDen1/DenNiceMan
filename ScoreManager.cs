using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public int language;

    private void Update()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }

    private void Start()
    {
        if (language == 0)
        {
            scoreDisplay.text = "Score: " + score.ToString();
        }
        else if (language == 1)
        {
            scoreDisplay.text = "—чет: " + score.ToString();
        }
    }

    public void Kill()
    {
        score++;
    }
}
