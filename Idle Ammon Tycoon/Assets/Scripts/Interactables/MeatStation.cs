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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onArea = true;
            if (!inProcessing)
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
        inProcessing = true;
        meatProcessButton.SetActive(false);
        meatWorker.SetBool("IsCutting", true);
        StartCoroutine(productionComplete());
    }

    private IEnumerator productionComplete()
    {
        yield return new WaitForSeconds(6f);
        inProcessing = false;
        meatWorker.SetBool("IsCutting", false);
        if (onArea)
        {
            meatProcessButton.SetActive(true);
        }
    }

}
