using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatCage : BaseClientManager
{
    public Animator zombie;
    public float eatTime;
    private float tempEatTime;
    public GameObject meatImage;
    public GameObject[] Flasks;
    private int currentFlask;

    public override void Update()
    {
        base.Update();
        if (tempEatTime < eatTime)
        {
            tempEatTime += Time.deltaTime;
            if (tempEatTime >= eatTime)
            {
                meatImage.SetActive(true);
                zombie.SetBool("Eating", false);
                Flasks[currentFlask].gameObject.SetActive(true);
                currentFlask++;

                if (currentFlask >= Flasks.Length)
                {
                    currentFlask = 0;
                }
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
                tempEatTime = 0;
            }

        }
    }
}
