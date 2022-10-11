using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BattleStationHelper : MonoBehaviour
{
    public CombatManager combatManager;
    public WorkersManager workerManager;
    public ClientsManager clientManager;
    public BattleStation station;
    public GameObject questionsPanel;
    public TMPro.TextMeshProUGUI contractText;
    public UnityEvent onContractSigned, onContractCompleted;
    public Button acceptButton;
    private PlayerHelper helper;
    public GameObject CompleteTrigger, DropPoint;

    [HideInInspector]
    public bool hasWorker, isBusy;

    private void OnEnable()
    {
        workerManager.battleStations.Add(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasWorker)
        {
            if (other.tag == "Player")
            {
                clientManager.passButtonFunctions();
                acceptButton.onClick.AddListener(() => acceptContract());
                helper = other.GetComponent<PlayerHelper>();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (helper != null && !hasWorker)
        {
            if (!helper.killContractSigned && !helper.gunContractSigned && !helper.hasMeat)
            {
                if (other.tag == "Player" && station.taskImage != null)
                {
                    isBusy = true;
                    contractText.text = station.contractDetail;
                    questionsPanel.SetActive(true);
                    station.taskImage.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (helper != null && !helper.killContractSigned)
            {
                isBusy = false;
            }
            questionsPanel.SetActive(false);
        }
    }

    public void acceptContract()
    {
        if (onContractSigned != null)
        {
            onContractSigned.Invoke();
            combatManager.Trigger = CompleteTrigger;
            combatManager.dropPoint = DropPoint.transform;
            helper.killContractSigned = true;
            isBusy = true;
        }
    }

}
