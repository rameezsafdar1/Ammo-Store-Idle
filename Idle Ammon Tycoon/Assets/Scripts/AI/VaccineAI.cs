using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineAI : BaseClientProperties
{
    private MeatCage cage;
    private bool hasVaccine;
    public GameObject Coin;
    public GameObject coinAnimation;

    public override void OnEnable()
    {
        base.OnEnable();
        hasVaccine = false;
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.tag == "VaccineSpot")
        {
            cage = other.GetComponent<MeatCage>();
            waitImage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "VaccineSpot")
        {
            if (cage != null && cage.availableVaccines > 0 && !hasVaccine)
            {
                waitImage.gameObject.SetActive(false);
                cage.vaccineTaken(this);
                finalPosition = cage.endPos;
                Agent.SetDestination(finalPosition.position);

                for (int i = 0; i < 3; i++)
                {
                    GameObject coin = Instantiate(Coin, transform.position, Quaternion.identity);
                    coin.GetComponent<Coin>().cashAnimation = coinAnimation;
                }
                hasVaccine = true;
            }
        }
    }

}
