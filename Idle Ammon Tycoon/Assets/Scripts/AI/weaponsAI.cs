using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponsAI : BaseClientProperties
{
    public Image waitFill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BuySpot")
        {
            taskImage.gameObject.SetActive(true);
        }
    }

}
