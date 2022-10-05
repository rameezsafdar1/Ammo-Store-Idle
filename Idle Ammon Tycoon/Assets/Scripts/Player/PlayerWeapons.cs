using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject pistol, rifle, shotgun;
    public Animator anim;
    public TextMeshProUGUI rifleText, shotGunText;
    public Button rifleButton, shotgunButton;

    private void Start()
    {
        checkRifleBuy();
    }

    public void enableGun()
    {
        anim.SetBool("Pistol", true);
        anim.SetBool("Rifle", false);
        anim.SetBool("Shotgun", false);
        pistol.gameObject.SetActive(true);
        rifle.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(false);
    }

    public void enableRifle()
    {
        anim.SetBool("Pistol", false);
        anim.SetBool("Rifle", true);
        anim.SetBool("Shotgun", false);
        pistol.gameObject.SetActive(false);
        rifle.gameObject.SetActive(true);
        shotgun.gameObject.SetActive(false);
    }

    public void enableShotgun()
    {
        anim.SetBool("Pistol", false);
        anim.SetBool("Rifle", false);
        anim.SetBool("Shotgun", true);
        pistol.gameObject.SetActive(false);
        rifle.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(true);
    }

    private void buyRifle()
    {
        if (saveManager.Instance.loadCash() >= 150)
        {
            saveManager.Instance.addCash(-350);
            saveManager.Instance.savePermanentGems();
            saveManager.Instance.saveCustomInts("Rifle", 1);
        }
        checkRifleBuy();
    }

    public void checkRifleBuy()
    {
        if (saveManager.Instance.loadCustomInts("Rifle") > 0)
        {
            rifleText.text = "Equip";
            rifleButton.onClick.RemoveAllListeners();
            rifleButton.onClick.AddListener(() => enableRifle());
        }
        else
        {
            rifleButton.onClick.RemoveAllListeners();
            rifleButton.onClick.AddListener(() => buyRifle());
        }
    }

}
