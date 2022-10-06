using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCorkBoard : MonoBehaviour
{
    public curveFollower[] weaponsOnBoard;
    public float waitTime;
    private float tempWait;
    private PlayerHelper helper;
    private int currentSoldGun;
    public Image fillImage;
    public curveFollower[] targetcubBoards;
    private Transform dropPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            helper = other.GetComponent<PlayerHelper>();
            if (dropPoint == null)
            {
                dropPoint = other.GetComponent<playerStats>().pickupPoint;
            }
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
                    takeGun();
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

    public void takeGun()
    {
        weaponsOnBoard[currentSoldGun].transform.parent = dropPoint;
        weaponsOnBoard[currentSoldGun].setMyTarget(dropPoint.transform.GetChild(0).transform.localPosition);
        targetcubBoards[currentSoldGun].transform.parent = dropPoint;
        targetcubBoards[currentSoldGun].setMyTarget(dropPoint.transform.GetChild(0).transform.localPosition);
        targetcubBoards[currentSoldGun].GetComponent<Animator>().SetTrigger("Animate");
        targetcubBoards[currentSoldGun].transform.localRotation = Quaternion.identity;
        StartCoroutine(wait(weaponsOnBoard[currentSoldGun].gameObject));
        currentSoldGun++;
    }
}
