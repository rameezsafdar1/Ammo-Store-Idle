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
    [SerializeField]
    private PlayerHelper helper;
    public Transform collectionPoint, happyParticles, endPosition;
    public GameObject Coin;
    public Transform cashAnimation, coinInstPoint;
    public bool signed;

    private void OnTriggerEnter(Collider other)
    {
        if (helper == null)
        {
            if (other.tag == "Player" || other.tag == "Worker")
            {
                helper = other.GetComponent<PlayerHelper>();
            }
        }

        if (helper != null)
        {
            if (helper.hasGunForSale && signed)
            {
                helper.hasGunForSale = false;
                helper.gunContractSigned = false;
                station.ai.waitImage.gameObject.SetActive(false);
                StartCoroutine(wait());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (helper != null)
        {
            if (!helper.killContractSigned && !helper.gunContractSigned)
            {
                if (other.tag == "Player" || other.tag == "Worker")
                {
                    if (station.taskImage != null)
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
                            signed = true;
                            if (onContractSigned != null)
                            {
                                onContractSigned.Invoke();
                            }
                            tempFillTime = 0;
                        }
                    }
                }
            }
        }

        else
        {
            if (other.tag == "Worker")
            {
                helper = other.GetComponent<PlayerHelper>();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && helper.mainPlayer && !helper.gunContractSigned)
        {
            helper = null;
            tempFillTime = 0;

            if (station.fillImage != null)
            {
                station.fillImage.fillAmount = 0;
            }
        }

    }

    private IEnumerator wait()
    {
        happyParticles.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        station.ai.finalPosition = endPosition;
        weaponClient.clientDealt();
        GameObject go = Instantiate(Coin, coinInstPoint.position, Quaternion.identity);
        go.GetComponent<Coin>().cashAnimation = cashAnimation.gameObject;
        signed = false;
    }

}
