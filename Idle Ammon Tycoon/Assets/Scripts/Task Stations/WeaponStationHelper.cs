using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponStationHelper : MonoBehaviour
{
    public WeaponStation station;
    public UnityEvent onContractSigned, onContractCompleted;
    public float fillTime;
    private float tempFillTime;
    private PlayerHelper helper;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            helper = other.GetComponent<PlayerHelper>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!EffectsManager.Instance.contractSigned && !helper.gunContractSigned)
        {
            if (other.tag == "Player" && station.taskImage != null)
            {
                tempFillTime += Time.deltaTime;
                station.fillImage.fillAmount = tempFillTime / fillTime;
                if (tempFillTime >= fillTime)
                {
                    helper.gunContractSigned = true;
                    station.taskImage.gameObject.SetActive(false);
                    station.waitImage.gameObject.SetActive(true);
                    station.fillImage.fillAmount = 0;

                    if (onContractSigned != null)
                    {
                        onContractSigned.Invoke();
                    }

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !helper.gunContractSigned)
        {
            helper = null;
            tempFillTime = 0;
            station.fillImage.fillAmount = 0;
        }
    }
}
