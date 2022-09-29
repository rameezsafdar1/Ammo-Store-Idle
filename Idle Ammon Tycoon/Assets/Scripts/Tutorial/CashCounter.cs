using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CashCounter : MonoBehaviour
{
    public int cashToCheck;
    public UnityEvent onCashCollected;

    private void Update()
    {
        if (saveManager.Instance.loadCash() >= cashToCheck)
        {
            if (onCashCollected != null)
            {
                onCashCollected.Invoke();
            }
        }
    }


}
