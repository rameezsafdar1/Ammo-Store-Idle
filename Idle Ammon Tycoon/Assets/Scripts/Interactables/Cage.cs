using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Cage : MonoBehaviour,iInteractable
{
    public float interactionTime;
    [SerializeField]
    private float tempInteractTime;
    public UnityEvent onInteractionComplete;
    public Image fillImage;

    private void OnEnable()
    {
        tempInteractTime = 0;
    }

    public void interact()
    {
        fillImage.fillAmount = tempInteractTime / interactionTime;
        if (tempInteractTime < interactionTime)
        {
            tempInteractTime += Time.deltaTime;

            if (tempInteractTime >= interactionTime)
            {
                if (onInteractionComplete != null)
                {
                    onInteractionComplete.Invoke();
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fillImage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            fillImage.gameObject.SetActive(false);
            if (tempInteractTime < interactionTime)
            {
                tempInteractTime = 0;
            }
        }
    }


}
