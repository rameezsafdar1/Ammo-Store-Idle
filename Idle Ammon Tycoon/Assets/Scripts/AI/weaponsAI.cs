using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponsAI : BaseClientProperties
{
    public Image waitFill;

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.tag == "BuySpot")
        {
            taskImage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BuySpot")
        {
            taskImage.gameObject.SetActive(false);
        }
    }
}
