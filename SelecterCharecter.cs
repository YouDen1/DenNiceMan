using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecterCharecter : MonoBehaviour
{
    SelecterCharecter.Data data = new SelecterCharecter.Data();
    private int i;

    public GameObject[] AllCharacter;

    public GameObject ArrowToLeft;
    public GameObject ArrowToRight;

    public GameObject ButtonBuyCharacter;
    public GameObject ButtonSelectCharacter;
    public GameObject TextSelectCharacter;

    private string statusCheck;
    private int check;

    public Text TextPrice;

    [System.Serializable]

    public class Data
    {
        public string currentCharacter = "DefaultDen";
        public List<string> haveCharacters = new List<string> { "DefaultDen" };
        public int money;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveGame"))
        {
            data = JsonUtility.FromJson<SelecterCharecter.Data>(PlayerPrefs.GetString("SaveGame"));
        }
        else
        {
            data.money = 50;
            PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(data));
        }

        AllCharacter[i].SetActive(false);

        if (data.currentCharacter == AllCharacter[i].name)
        {
            ButtonBuyCharacter.SetActive(false);
            ButtonSelectCharacter.SetActive(false);
            TextSelectCharacter.SetActive(true);
        }
        else if (data.currentCharacter != AllCharacter[i].name)
        {
            StartCoroutine(CheckHaveCharacter());
        }
    }

    public IEnumerable CheckHaveCharacter()
    {
        while (statusCheck != "DefaultDen")
        {
            if (data.haveCharacters.Count != check)
            {
                if (AllCharacter[i].name != data.haveCharacters[check])
                {
                    check++;
                }
                else if (AllCharacter[i].name == data.haveCharacters[check])
                {
                    ButtonSelectCharacter.SetActive(false);
                    TextSelectCharacter.SetActive(false);
                    ButtonSelectCharacter.SetActive(true);
                    check = 0;
                    statusCheck = "DefaultDen";
                }
                else if (data.haveCharacters.Count == check)
                {
                    TextSelectCharacter.SetActive(false);
                    ButtonBuyCharacter.SetActive(true);
                    TextPrice.text = AllCharacter[i].GetComponent<Item>().priceCharacter.ToString();
                    check = 0;
                    statusCheck = "DefaultDen";
                }
            }
        }
        statusCheck = "";

        yield return null;
    }

    public void ArrowRight()
    {
        if (i < AllCharacter.Length)
        {
            if (i == 0)
            {
                ArrowToLeft.SetActive(true);
            }

            AllCharacter[i].SetActive(false);
            i++;
            AllCharacter[i].SetActive(true);

            if (data.currentCharacter == AllCharacter[i].name)
            {
                ButtonBuyCharacter.SetActive(false);
                ButtonSelectCharacter.SetActive(false);
                TextSelectCharacter.SetActive(true);
            }
            else if (data.currentCharacter != AllCharacter[i].name)
            {
                StartCoroutine(CheckHaveCharacter());
            }

            if (i + 1 == AllCharacter.Length)
            {
                ArrowToRight.SetActive(false);
            }
        }
    }
    public void ArrowLeft()
    {
        if (i < AllCharacter.Length)
        {
            AllCharacter[i].SetActive(false);
            i--;
            AllCharacter[i].SetActive(true);
            ArrowToRight.SetActive(true);

            if (data.currentCharacter == AllCharacter[i].name)
            {
                ButtonBuyCharacter.SetActive(false);
                ButtonSelectCharacter.SetActive(false);
                TextSelectCharacter.SetActive(true);
            }
            else if (data.currentCharacter != AllCharacter[i].name)
            {
                StartCoroutine(CheckHaveCharacter());
            }

            if (i == 0)
            {
                ArrowToLeft.SetActive(false);
            }
        }
    }

    public void SelectCharacter()
    {
        data = JsonUtility.FromJson<SelecterCharecter.Data>(PlayerPrefs.GetString("SaveGame"));
        data.currentCharacter = AllCharacter[i].name;
        PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(data));

        ButtonSelectCharacter.SetActive(false);
        TextSelectCharacter.SetActive(true);
    }

    public void BuyCharacter()
    {
        if(data.money >= AllCharacter[i].GetComponent<Item>.priceCharacter)
        {
            data = JsonUtility.FromJson<SelecterCharecter.Data>(PlayerPrefs.GetString("SaveGame"));

            data.money = data.money - AllCharacter[i].GetComponent<Item>().priceCharacter;
            data.haveCharacters.Add(AllCharacter[i].name);

            PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(data));

            ButtonSelectCharacter.SetActive(false);
            ButtonBuyCharacter.SetActive(false);
        }

    }
}
