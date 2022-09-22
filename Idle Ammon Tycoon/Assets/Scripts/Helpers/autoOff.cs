using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoOff : MonoBehaviour
{
    public float delay;
    private float tempTime;

    private void OnEnable()
    {
        tempTime = 0;
    }

    private void Update()
    {
        tempTime += Time.deltaTime;

        if (tempTime >= delay)
        {
            tempTime = 0;
            gameObject.SetActive(false);
        }
    }

    public void resetTime()
    {
        tempTime = 0;
    }
}
