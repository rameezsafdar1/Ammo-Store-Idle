using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleStation : MonoBehaviour
{
    [HideInInspector]
    public Image waitImage, taskImage;
    public contractAI ai;
    public string contractDetail;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            ai = other.GetComponent<contractAI>();
            contractDetail = ai.contractDetails[Random.Range(0, ai.contractDetails.Length)];
            waitImage = ai.waitImage;
            taskImage = ai.taskImage;
        }
    }
}
