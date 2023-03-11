using UnityEngine;
using UnityEngine.UI;

public class maxTimeManager : MonoBehaviour
{
    public int seconds;
    private float times;
    public Text Text;

    void Update()
    {
        times += 1 * Time.deltaTime;
        if (times > 1)
        {
            seconds += 1;
            times = 0;
        }
        Text.text = "Time: " + seconds.ToString() + "s";
        PlayerPrefs.SetFloat("maxTime", seconds);
    }
}
