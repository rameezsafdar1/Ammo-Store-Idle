using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOnBoard : MonoBehaviour
{
    public Transform initialParent;
    private Vector3 initpos;
    private bool activated;

    private void OnEnable()
    {
        transform.parent = initialParent;
        if (activated)
        {
            transform.localPosition = initpos;
        }
    }

    private void Start()
    {
        initpos = transform.localPosition;
        activated = true;
    }

}
