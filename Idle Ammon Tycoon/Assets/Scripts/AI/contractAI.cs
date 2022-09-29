using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contractAI : BaseClientProperties
{
    public string[] contractDetails;


    public override void OnEnable()
    {
        base.OnEnable();
        transform.tag = "AI";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HelpDesk")
        {
            if (!consumed)
            {
                taskImage.gameObject.SetActive(true);
            }
        }

        if (other.tag == "Finish")
        {
            gameObject.SetActive(false);
        }

    }
}
