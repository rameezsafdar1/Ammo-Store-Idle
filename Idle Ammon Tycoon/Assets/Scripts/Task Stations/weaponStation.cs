using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponStation : MonoBehaviour
{
    [HideInInspector]
    public Image waitImage, taskImage;
    public weaponsAI ai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            ai = other.GetComponent<weaponsAI>();
            waitImage = ai.waitImage;
            taskImage = ai.taskImage;
        }
    }
}
