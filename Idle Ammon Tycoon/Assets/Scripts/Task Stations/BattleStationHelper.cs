using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BattleStationHelper : MonoBehaviour
{
    public BattleStation station;
    public GameObject questionsPanel;
    public TMPro.TextMeshProUGUI contractText;
    public UnityEvent onContractSigned, onContractCompleted;
    public Button acceptButton;
    private PlayerHelper helper;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            acceptButton.onClick.AddListener(() => acceptContract());
            helper = other.GetComponent<PlayerHelper>();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (helper != null)
        {
            if (!helper.killContractSigned && !helper.gunContractSigned)
            {
                if (other.tag == "Player" && station.taskImage != null)
                {
                    contractText.text = station.contractDetail;
                    questionsPanel.SetActive(true);
                    station.taskImage.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        questionsPanel.SetActive(false);
    }

    public void acceptContract()
    {
        if (onContractSigned != null)
        {
            onContractSigned.Invoke();
            helper.killContractSigned = true;
        }
    }

}
