using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public GameObject cashAnimation;

    public void AddCash()
    {
        saveManager.Instance.addCash(value);
        saveManager.Instance.fillDayBar();
        cashAnimation.SetActive(true);
        Destroy(gameObject);
    }
}
