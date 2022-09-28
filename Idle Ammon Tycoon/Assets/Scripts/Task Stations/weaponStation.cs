using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStation : MonoBehaviour
{
    [HideInInspector]
    public Image waitImage, taskImage, fillImage;
    public weaponsAI ai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Buyer")
        {
            ai = other.GetComponent<weaponsAI>();
            fillImage = ai.waitFill;
            waitImage = ai.waitImage;
            taskImage = ai.taskImage;
        }
    }
}
