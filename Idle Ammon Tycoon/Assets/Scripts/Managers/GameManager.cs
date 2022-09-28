using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Levels;
    private int currentLevel;

    private void Awake()
    {
        Levels[currentLevel].SetActive(true);
    }
}
