using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleStation : MonoBehaviour
{
    [HideInInspector]
    public Image playerFill, endFill, waitImage, taskImage;
    public BaseClientProperties bcp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            bcp = other.GetComponent<BaseClientProperties>();
            playerFill = bcp.fillImage;
            waitImage = bcp.waitImage;
            taskImage = bcp.taskImage;
            endFill = bcp.endFill;
        }
    }
}
