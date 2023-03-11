using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int money;
    public Text moneyText;
    void Update()
    {
        moneyText.text = "Money: " + money.ToString();
    }

    public void GiveMoney()
    {
        money++;
    }
}
