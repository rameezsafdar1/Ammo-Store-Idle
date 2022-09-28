using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCorkBoard : MonoBehaviour
{
    public GameObject[] weaponsOnBoard;
    public float waitTime;
    private float tempWait;
    private PlayerHelper helper;
    private int currentSoldGun;
    public Image fillImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            helper = other.GetComponent<PlayerHelper>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && currentSoldGun < weaponsOnBoard.Length)
        {
            if (helper.gunContractSigned && !helper.hasGunForSale)
            {
                tempWait += Time.deltaTime;
                fillImage.fillAmount = tempWait / waitTime;
                if (tempWait >= waitTime)
                {
                    helper.hasGunForSale = true;
                    weaponsOnBoard[currentSoldGun].gameObject.SetActive(false);
                    StartCoroutine(wait(weaponsOnBoard[currentSoldGun]));
                    currentSoldGun++;
                    tempWait = 0;
                    fillImage.fillAmount = tempWait;
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !helper.hasGunForSale)
        {
            tempWait = 0;
            fillImage.fillAmount = tempWait;
        }
    }

    private IEnumerator wait(GameObject go)
    {
        yield return new WaitForSeconds(3f);
        go.SetActive(true);
        currentSoldGun--;
    }

}
