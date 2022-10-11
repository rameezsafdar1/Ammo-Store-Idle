using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatCage : MonoBehaviour
{
    public Animator zombie;
    public float eatTime;
    private float tempTime;
    public GameObject meatImage;

    private void Update()
    {
        if (tempTime < eatTime)
        {
            tempTime += Time.deltaTime;
            if (tempTime >= eatTime)
            {
                meatImage.SetActive(true);
                zombie.SetBool("Eating", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && tempTime >= eatTime)
        {
            PlayerHelper helper = other.GetComponent<PlayerHelper>();

            if (helper != null && helper.hasMeat)
            {
                helper.hasMeat = false;
                helper.meatInHand.SetActive(false);
                helper.anim.SetBool("Holding", false);
                meatImage.SetActive(false);
                zombie.SetBool("Eating", true);
                tempTime = 0;
            }

        }
    }
}
