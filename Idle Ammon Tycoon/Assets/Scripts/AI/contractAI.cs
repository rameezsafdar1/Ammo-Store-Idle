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

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.tag == "HelpDesk")
        {
            if (!consumed)
            {
                taskImage.gameObject.SetActive(true);
            }
        }
    }
}
