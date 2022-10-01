using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool debug;
    public GameObject[] Levels;
    public int currentLevel;

    private void Awake()
    {
        if (!debug)
        {
            currentLevel = saveManager.Instance.loadCustomInts("Level");
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            Levels[currentLevel].SetActive(true);
        }
    }

    public void nextLevel()
    {
        saveManager.Instance.savePermanentGems();
        currentLevel++;
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }

        if (currentLevel >= Levels.Length)
        {
            currentLevel = Levels.Length - 1;
        }

        Levels[currentLevel].SetActive(true);
        saveManager.Instance.saveCustomInts("Level", currentLevel);
    }
}
