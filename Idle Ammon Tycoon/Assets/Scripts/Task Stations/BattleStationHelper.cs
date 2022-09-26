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

    private void Start()
    {
        acceptButton.onClick.AddListener(() => acceptContract());
    }

    private void OnTriggerStay(Collider other)
    {
        if (!EffectsManager.Instance.contractSigned)
        {
            if (other.tag == "Player" && station.taskImage != null)
            {
                contractText.text = station.contractDetail;
                questionsPanel.SetActive(true);
                station.taskImage.gameObject.SetActive(true);
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
            EffectsManager.Instance.contractSigned = true;
        }
    }

}
