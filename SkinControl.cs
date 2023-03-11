using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinControl : MonoBehaviour
{
    public static int selectedSkin;
    public int skinNum;
    public Button buyButton;
    public int price;
    public int money;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;

    public Image[] skins;


    void Start()
    {
        if (PlayerPrefs.GetInt("skin1" + "buy") == 0)
        {
            foreach (Image img in skins)
            {
                if("skin1" == img.name)
                {
                    PlayerPrefs.SetInt("skin1" + "buy", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 0);
                }
            }
        }
    }

    void Update()
    {
        money = PlayerPrefs.GetInt("money");
        if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            buyButton.GetComponent<Image>().sprite = buySkin;
        }
        else if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            if(PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 1)
            {
                buyButton.GetComponent<Image>().sprite = equipped;
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "equip") == 0)
            {
                buyButton.GetComponent<Image>().sprite = equip;
            }
        }
    }

    public void buy()
    {
        if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (GetComponent<Money>().money >= price)
            {
                buyButton.GetComponent<Image>().sprite = equipped;
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);

                foreach(Image img in skins)
                {
                    if (GetComponent<Image>().name == img.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(img.name + "equip", 0);
                    }
                }
            }
                else if(PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
            {
                    buyButton.GetComponent<Image>().sprite = equipped;
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                    PlayerPrefs.SetInt("skinNum", skinNum);

                    foreach(Image img in skins)
                    {
                        if (GetComponent<Image>().name == img.name)
                        {
                            PlayerPrefs.SetInt(GetComponent<Image>().name + "equip", 1);
                        }
                        else
                        {
                            PlayerPrefs.SetInt(img.name + "equip", 0);
                        }
                    }
                }
        }
    }
}
