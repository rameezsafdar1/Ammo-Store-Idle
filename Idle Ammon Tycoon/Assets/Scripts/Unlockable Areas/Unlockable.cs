using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Unlockable : MonoBehaviour
{
    public int Price;
    public TextMeshPro priceText;
    private int availableCash;
    public UnityEvent onUnlock; 

    private void Start()
    {
        priceText.text = Price.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            availableCash = saveManager.Instance.loadCash();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && availableCash >= Price)
        {
            Price -= 5;
            saveManager.Instance.addCash(-5);
            priceText.text = Price.ToString();

            if (Price <= 0)
            {
                if (onUnlock != null)
                {
                    onUnlock.Invoke();
                }
            }

        }
    }


}
