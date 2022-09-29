using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public float doorHealth;
    public Button repairButton;
    public UnityEvent buttonEvents;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            repairButton.onClick.RemoveAllListeners();
            repairButton.onClick.AddListener(() => buttonEvents.Invoke());
            repairButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            repairButton.gameObject.SetActive(false);
        }
    }

}
