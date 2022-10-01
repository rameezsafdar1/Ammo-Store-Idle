using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class saveManager : MonoBehaviour
{
    public static saveManager Instance;
    private float currentDayNumber;
    private int totalCash, totalGems;
    public TextMeshProUGUI cashText, gemsText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        addCash(0);
        addGem(0);
    }

    public void addCash(int cash)
    {
        totalCash = PlayerPrefs.GetInt("Cash");
        totalCash += cash;
        PlayerPrefs.SetInt("Cash", totalCash);
        cashText.text = EffectsManager.Instance.currencyShortener((float)totalCash);
    }

    public void addGem()
    {
        totalGems = PlayerPrefs.GetInt("Gems");
        totalGems += 1;
        PlayerPrefs.SetInt("Gems", totalGems);
        gemsText.text = EffectsManager.Instance.currencyShortener((float)totalGems) + " / 30";
    }

    public void addGem(int gems)
    {
        totalGems = PlayerPrefs.GetInt("Gems");
        totalGems += gems;
        PlayerPrefs.SetInt("Gems", totalGems);
        gemsText.text = EffectsManager.Instance.currencyShortener((float)totalGems) + " / 30";
    }

    public int loadCash()
    {
        totalCash = PlayerPrefs.GetInt("Cash");
        return totalCash;
    }

    public float currentDay()
    {
        currentDayNumber = PlayerPrefs.GetFloat("currentDay");
        return currentDayNumber;
    }

    public float loadDay()
    {
        currentDayNumber = PlayerPrefs.GetFloat("currentDay");
        return currentDayNumber;
    }

    public void updateDay(int maxDays)
    {
        currentDayNumber = PlayerPrefs.GetFloat("currentDay");
        currentDayNumber++;

        if (currentDayNumber >= maxDays)
        {
            currentDayNumber = 0;
            PlayerPrefs.DeleteAll();
        }

        PlayerPrefs.SetFloat("currentDay", currentDayNumber);
    }

    public void saveCustomFloats(string s, float value)
    {
        PlayerPrefs.SetFloat(s, value);
    }

    public void saveCustomFloats(string s)
    {
        PlayerPrefs.SetFloat(s, 1);
    }

    public void saveLevelComplete(int x)
    {
        PlayerPrefs.SetInt("currentLevel", x);
        int chapter = PlayerPrefs.GetInt("chapter");
        chapter += 1;
        PlayerPrefs.SetInt("chapter", chapter);
    }

    public float loadCustomFloats(string s)
    {
        float customFloat = PlayerPrefs.GetFloat(s);
        return customFloat;
    }

    public int loadCustomInts(string s)
    {
        int customInt = PlayerPrefs.GetInt(s);
        return customInt;
    }

    public void saveCustomInts(string s, int value)
    {
        PlayerPrefs.SetInt(s, value);
    }


}
