using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUnlockManager : MonoBehaviour
{
    public Button rifleButton, shotGunButton;

    private void OnEnable()
    {
        if (saveManager.Instance.loadCustomInts("Rifle") > 0)
        {
            rifleButton.interactable = true;
        }

        if (saveManager.Instance.loadCustomInts("Shotgun") > 0)
        {
            shotGunButton.interactable = true;
        }

    }
}
