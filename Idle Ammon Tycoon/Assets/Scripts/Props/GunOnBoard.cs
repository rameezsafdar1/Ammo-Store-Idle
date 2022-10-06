using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOnBoard : MonoBehaviour
{
    public Transform initialParent;
    private Vector3 initpos;
    private Quaternion initrot;
    private bool activated;

    private void OnEnable()
    {
        transform.parent = initialParent;
        if (activated)
        {
            transform.localPosition = initpos;
            transform.localRotation = initrot;
        }
    }

    private void Start()
    {
        initpos = transform.localPosition;
        initrot = transform.localRotation;
        activated = true;
    }

}
