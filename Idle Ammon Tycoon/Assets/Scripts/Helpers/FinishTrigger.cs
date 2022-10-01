using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public ActivityManager activity;

    private void OnTriggerEnter(Collider other)
    {
        if (activity != null)
        {
            if (other.tag == "Client" || other.tag == "Buyer" || other.tag == "AI")
            {
                activity.eventDone();
            }
        }
    }
}
