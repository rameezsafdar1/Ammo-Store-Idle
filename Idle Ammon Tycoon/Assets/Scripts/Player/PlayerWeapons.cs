using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
