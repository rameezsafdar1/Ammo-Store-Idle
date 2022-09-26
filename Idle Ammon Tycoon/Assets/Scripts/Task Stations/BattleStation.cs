using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleStation : MonoBehaviour
{
    [HideInInspector]
    public Image waitImage, taskImage;
    public BaseClientProperties bcp;
    public string contractDetail;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            bcp = other.GetComponent<BaseClientProperties>();
            contractDetail = bcp.contractDetails[Random.Range(0, bcp.contractDetails.Length)];
            waitImage = bcp.waitImage;
            taskImage = bcp.taskImage;
        }
    }
}
