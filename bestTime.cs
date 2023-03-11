using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bestTime : MonoBehaviour
{
    private float _bestTime;
    public Text maxTime;

    private void Start()
    {
        BestTime();
    }
    public void BestTime()
    {
        _bestTime = PlayerPrefs.GetFloat("maxTime");
        maxTime.text = "Best Time: " + _bestTime.ToString() + "s";
    }
}
