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
    public GameObject locator;

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
                    helper.anim.SetBool("Holding", true);
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

    private IEnumerator wait(GameObject go, float duration, bool gunSold)
    {
        yield return new WaitForSeconds(duration);
        go.SetActive(true);
        if (gunSold)
        {
            currentSoldGun--;
        }
    }

    public void takeGun()
    {
        if (locator != null)
        {
            locator.SetActive(false);
        }
        weaponsOnBoard[currentSoldGun].transform.parent = dropPoint;
        weaponsOnBoard[currentSoldGun].setMyTarget(dropPoint.transform.GetChild(0).transform.localPosition);
        targetcubBoards[0].transform.parent = dropPoint;
        targetcubBoards[0].setMyTarget(dropPoint.transform.GetChild(0).transform.localPosition);
        targetcubBoards[0].GetComponent<Animator>().SetTrigger("Animate");
        targetcubBoards[0].transform.localRotation = Quaternion.identity;
        StartCoroutine(wait(weaponsOnBoard[currentSoldGun].gameObject, 3f, true));
        StartCoroutine(wait(targetcubBoards[0].gameObject, 1f, false));
        currentSoldGun++;
    }

    public void takeGunAI()
    {
        weaponsOnBoard[currentSoldGun].gameObject.SetActive(false);
        StartCoroutine(wait(weaponsOnBoard[currentSoldGun].gameObject, 3f, true));
        currentSoldGun++;
    }
}
