using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public splash loading;
    private void Start()
    {
        int Level = saveManager.Instance.loadCustomInts("Level");

        if (Level >= 3)
        {
            loading.loadLevel = 2;
        }
        else
        {
            loading.loadLevel = 1;
        }
        loading.enabled = true;
    }
}
