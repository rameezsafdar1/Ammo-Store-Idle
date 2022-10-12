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
    public int availableVaccines;
    [SerializeField]
    private int availableMeat;

    public override void Update()
    {
        if (currentDestination >= destinationPoints.Count)
        {
            currentDestination = 0;
        }
        base.Update();
        if (tempEatTime < eatTime && availableVaccines < Flasks.Length && availableMeat > 0)
        {
            tempEatTime += Time.deltaTime;
            if (tempEatTime >= eatTime)
            {
                meatImage.SetActive(true);
                zombie.SetBool("Eating", false);
                Flasks[currentFlask].gameObject.SetActive(true);
                currentFlask++;
                availableVaccines++;
                availableMeat--;
                if (currentFlask >= Flasks.Length)
                {
                    currentFlask = 0;
                }
                tempEatTime = 0;

                if (availableMeat > 0)
                {
                    meatImage.SetActive(false);
                    zombie.SetBool("Eating", true);
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHelper helper = other.GetComponent<PlayerHelper>();

            if (helper != null && helper.hasMeat)
            {
                availableMeat++;
                helper.hasMeat = false;
                helper.meatInHand.SetActive(false);
                helper.anim.SetBool("Holding", false);
                meatImage.SetActive(false);
                zombie.SetBool("Eating", true);
            }

        }
    }

    public void vaccineTaken(BaseClientProperties client)
    {
        availableVaccines--;

        if (availableVaccines < 0)
        {
            availableVaccines = 0;
        }

        clientsPool.Add(client);
        clientsEngaged.Remove(client);
        Flasks[currentFlask].SetActive(false);
        currentFlask--;

        if (currentFlask < 0)
        {
            currentFlask = 0;
        }
    }

}
