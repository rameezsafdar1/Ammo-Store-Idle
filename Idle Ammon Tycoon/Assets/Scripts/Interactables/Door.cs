using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public float doorHealth;
    private float tempHealth;
    public Button repairButton;
    public UnityEvent buttonEvents, onDoorHealthDown;
    private void Start()
    {
        if (doorHealth > 0)
        {
            tempHealth = doorHealth;
            if (buttonEvents != null)
            {
                buttonEvents.Invoke();
            }
        }
    }

    private void Update()
    {
        if (doorHealth > 0)
        {
            doorHealth -= 2 * Time.deltaTime;

            if (doorHealth <= 0)
            {
                if (onDoorHealthDown != null)
                {
                    onDoorHealthDown.Invoke();
                    doorHealth = 0;
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            repairButton.onClick.RemoveAllListeners();
            repairButton.onClick.AddListener(() => buttonEvents.Invoke());
            repairButton.onClick.AddListener(() => setHealth(tempHealth));
            repairButton.gameObject.SetActive(true);

            if (doorHealth <= 0)
            {
                repairButton.interactable = true;
            }
            else
            {
                repairButton.interactable = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            repairButton.gameObject.SetActive(false);
        }
    }

    public void setHealth(float health)
    {
        doorHealth = health;
        if (doorHealth <= 0)
        {
            if (onDoorHealthDown != null)
            {
                onDoorHealthDown.Invoke();
                doorHealth = 0;
            }
        }
    }

}
