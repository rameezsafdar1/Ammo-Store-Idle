using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleStation : MonoBehaviour
{
    //[HideInInspector]
    public Image waitImage, taskImage;
    public contractAI ai;
    public string contractDetail;

    public void setDetails(contractAI cai)
    {
        ai = cai;
        contractDetail = ai.contractDetails[Random.Range(0, ai.contractDetails.Length)];
        waitImage = ai.waitImage;
        taskImage = ai.taskImage;
    }

    public void resetDetails()
    {
        waitImage = null;
        taskImage = null;
        ai = null;
        contractDetail = "";
    }
}
