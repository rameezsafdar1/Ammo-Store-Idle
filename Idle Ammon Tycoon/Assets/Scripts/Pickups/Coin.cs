using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public GameObject cashAnimation;

    private void OnEnable()
    {
        gameObject.layer = 8;
    }

    public void AddCash()
    {
        saveManager.Instance.addCash(value);
        saveManager.Instance.fillDayBar();
        cashAnimation.SetActive(true);
        Destroy(gameObject);
    }
}
