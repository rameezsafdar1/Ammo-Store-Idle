using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatStation : MonoBehaviour
{
    public GameObject meatProcessButton;
    public bool inProcessing;
    public Animator meatWorker;
    private bool onArea;
    public curveFollower meatObject;
    public PlayerHelper helper;
    public Transform meatParent, meatInitPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onArea = true;
            if (!inProcessing && !helper.hasGunForSale && !helper.killContractSigned)
            {
                meatProcessButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onArea = false;
        }
    }

    public void startMeatProduction()
    {
        if (saveManager.Instance.loadGems() >= 10)
        {
            inProcessing = true;
            meatProcessButton.SetActive(false);
            meatWorker.SetBool("IsCutting", true);
            StartCoroutine(productionComplete());
        }
    }

    private IEnumerator productionComplete()
    {
        yield return new WaitForSeconds(5.5f);
        meatObject.transform.parent = meatParent;
        meatObject.transform.localPosition = meatInitPos.localPosition;
        meatObject.gameObject.layer = 8;
        meatObject.gameObject.SetActive(true);
        inProcessing = false;
        meatWorker.SetBool("IsCutting", false);
        if (onArea)
        {
            meatProcessButton.SetActive(true);
        }
    }

    public void setPlayerMeat()
    {
        helper.hasMeat = true;
        helper.anim.SetBool("Holding", true);
    }
}
