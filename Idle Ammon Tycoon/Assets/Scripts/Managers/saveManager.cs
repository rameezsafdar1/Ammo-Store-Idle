using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class saveManager : MonoBehaviour
{
    public static saveManager Instance;
    private int currentDayNumber;
    private int totalCash, totalGems;
    public TextMeshProUGUI cashText, gemsText, currentDayText, nextDayText;
    public Image dayBarFiller;
    [HideInInspector]
    public int cashCollectionTarget, collectedCashInLevel;
    [HideInInspector]
    public LevelManager levelManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        totalGems = PlayerPrefs.GetInt("Gems");
        totalCash = PlayerPrefs.GetInt("Cash");
        addCash(0);
        addGem(0);
        currentDayText.text = (currentDay() + 1).ToString();
        nextDayText.text = (currentDayNumber + 2).ToString();
    }

    public void addCash(int cash)
    {
        totalCash += cash;
        cashText.text = EffectsManager.Instance.currencyShortener((float)totalCash);
    }

    public void addGem()
    {
        totalGems += 1;
        gemsText.text = EffectsManager.Instance.currencyShortener((float)totalGems);
    }

    public void savePermanentGems()
    {
        PlayerPrefs.SetInt("Gems", totalGems);
        PlayerPrefs.SetInt("Cash", totalCash);
    }

    public void addGem(int gems)
    {
        totalGems += gems;
        gemsText.text = EffectsManager.Instance.currencyShortener((float)totalGems);
    }

    public int loadCash()
    {
        return totalCash;
    }

    public int loadGems()
    {
        return totalGems;
    }

    public int currentDay()
    {
        currentDayNumber = PlayerPrefs.GetInt("currentDay");
        return currentDayNumber;
    }

    public void updateDay()
    {
        currentDayNumber++;
        PlayerPrefs.SetInt("currentDay", currentDayNumber);
        currentDayText.text = (currentDay() + 1).ToString();
        nextDayText.text = (currentDayNumber + 2).ToString();
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

    public void fillDayBar()
    {
        if (cashCollectionTarget > 0)
        {
            collectedCashInLevel++;
            dayBarFiller.fillAmount = (float)collectedCashInLevel / (float)cashCollectionTarget;
            if (collectedCashInLevel >= cashCollectionTarget)
            {
                levelManager.stopClientInflux();
            }
        }

    }

}
