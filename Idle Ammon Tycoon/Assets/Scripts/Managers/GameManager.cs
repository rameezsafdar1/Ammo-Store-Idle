using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool debug;
    public GameObject[] Levels;
    private int currentLevel;
    public int levelNumber;

    private void Awake()
    {
        if (!debug)
        {
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            Levels[levelNumber].SetActive(true);
        }
    }
}
