using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleStation : MonoBehaviour
{
    [HideInInspector]
    public Image playerFill, waitImage, taskImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            BaseClientProperties bcp = other.GetComponent<BaseClientProperties>();
            playerFill = bcp.fillImage;
            waitImage = bcp.waitImage;
            taskImage = bcp.taskImage;
        }
    }
}
