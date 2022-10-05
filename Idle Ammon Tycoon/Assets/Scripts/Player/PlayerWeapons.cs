using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject pistol, rifle, shotgun;
    public Animator anim;

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

}
