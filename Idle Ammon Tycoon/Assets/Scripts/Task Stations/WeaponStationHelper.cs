using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponStationHelper : MonoBehaviour
{
    public WeaponStation station;
    public weaponsClientManager weaponClient;
    public UnityEvent onContractSigned, onContractCompleted;
    public float fillTime;
    private float tempFillTime;
    private PlayerHelper helper;
    public Transform happyParticles, endPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            helper = other.GetComponent<PlayerHelper>();
        }

        if (helper.hasGunForSale)
        {
            helper.hasGunForSale = false;
            helper.gunContractSigned = false;
            station.ai.waitImage.gameObject.SetActive(false);
            StartCoroutine(wait());
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (!helper.killContractSigned && !helper.gunContractSigned)
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
                    station.taskImage = null;
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

    private IEnumerator wait()
    {
        happyParticles.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        station.ai.finalPosition = endPosition;
        weaponClient.clientDealt();
    }

}
