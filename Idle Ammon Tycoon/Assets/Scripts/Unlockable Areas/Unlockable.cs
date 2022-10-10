using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Unlockable : MonoBehaviour
{
    public int Price, Gems;
    public TextMeshPro priceText, GemsText;
    private int availableCash, availableGems;
    public UnityEvent onUnlock;

    private void Start()
    {
        priceText.text = Price.ToString();

        if (GemsText != null)
        {
            GemsText.text = Gems.ToString();
        }

        if (Price <= 0  && Gems <= 0 || saveManager.Instance.loadCustomInts(transform.name) > 0)
        {
            if (onUnlock != null)
            {
                onUnlock.Invoke();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            availableCash = saveManager.Instance.loadCash();
            availableGems = saveManager.Instance.loadGems();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Gems > 0)
        {
            if (other.tag == "Player" && availableGems >= 5)
            {
                availableGems -= 5;
                Gems -= 5;
                saveManager.Instance.addGem(-5);
                GemsText.text = Gems.ToString();
            }
        }

        if (Price > 0)
        {
            if (other.tag == "Player" && availableCash >= 5)
            {
                availableCash -= 5;
                Price -= 5;
                saveManager.Instance.addCash(-5);
                priceText.text = Price.ToString();
            }
        }

        if (Price <= 0 && Gems <= 0)
        {
            saveManager.Instance.saveCustomInts(transform.name, 1);
            saveManager.Instance.savePermanentGems();
            if (onUnlock != null)
            {
                onUnlock.Invoke();
            }
        }
    }
}
