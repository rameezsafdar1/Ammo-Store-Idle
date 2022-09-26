using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleStationHelper : MonoBehaviour
{
    public BattleStation station;
    public float fillTime;
    private float tempFillTime;
    public UnityEvent onContractSigned, onContractCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (!EffectsManager.Instance.contractSigned)
        {
            if (other.tag == "Player" && station.playerFill != null)
            {
                station.playerFill.gameObject.SetActive(true);
            }
        }

        if (EffectsManager.Instance.contractCompleted && station.endFill != null)
        {
            station.waitImage.gameObject.SetActive(false);
            station.endFill.fillAmount = 0;
            station.endFill.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!EffectsManager.Instance.contractSigned) 
        {
            if (other.transform.tag == "Player" && station.playerFill != null)
            {
                tempFillTime += Time.deltaTime;
                station.playerFill.fillAmount = tempFillTime / fillTime;
                if (tempFillTime >= fillTime)
                {
                    station.playerFill.gameObject.SetActive(false);
                    station.taskImage.transform.parent.gameObject.SetActive(false);
                    station.waitImage.gameObject.SetActive(true);
                    station.playerFill = null;
                    EffectsManager.Instance.contractSigned = true;
                    if (onContractSigned != null)
                    {
                        onContractSigned.Invoke();
                    }
                    tempFillTime = 0;
                }

            }
        }

        if (EffectsManager.Instance.contractCompleted)
        {
            if (other.transform.tag == "Player" && station.endFill != null)
            {
                tempFillTime += Time.deltaTime;
                station.endFill.fillAmount = tempFillTime / fillTime;
                if (tempFillTime >= fillTime)
                {
                    station.bcp.contractOver();
                    station.endFill.gameObject.SetActive(false);
                    station.endFill = null;
                    EffectsManager.Instance.contractSigned = false;
                    EffectsManager.Instance.contractCompleted = false;
                    if (onContractCompleted != null)
                    {
                        onContractCompleted.Invoke();
                    }
                    tempFillTime = 0;
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!EffectsManager.Instance.contractSigned)
        {
            if (other.tag == "Player" && station.playerFill != null)
            {
                station.playerFill.gameObject.SetActive(false);
                if (tempFillTime < fillTime)
                {
                    tempFillTime = 0;
                }
            }
        }

        if (EffectsManager.Instance.contractCompleted && station.endFill != null)
        {
            tempFillTime = 0;
            station.endFill.gameObject.SetActive(false);
        }

    }

}
