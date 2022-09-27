using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class BaseClientProperties : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform targetPosition, finalPosition;
    public Image taskImage, fillImage, endFill, waitImage;
    public float accuracy;
    public Animator anim;
    public string[] contractDetails;
    public bool consumed;

    private void OnEnable()
    {
        consumed = false;
        transform.tag = "AI";
    }

    public virtual void Update()
    {
        anim.SetFloat("Velocity", Agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HelpDesk")
        {
            if (!consumed)
            {
                taskImage.gameObject.SetActive(true);
            }
        }
    }
}
