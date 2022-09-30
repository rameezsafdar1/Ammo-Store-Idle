using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class BaseClientProperties : MonoBehaviour
{
    public NavMeshAgent Agent;
    //[HideInInspector]
    public Transform targetPosition, finalPosition;
    public Image taskImage, waitImage;
    public float accuracy;
    public Animator anim;
    public bool consumed;

    public virtual void OnEnable()
    {
        consumed = false;        
        Agent.SetDestination(targetPosition.position);
    }

    public virtual void Update()
    {
        anim.SetFloat("Velocity", Agent.velocity.magnitude); 
        if (Agent.velocity.magnitude <= 0.1f && targetPosition != null)
        {
            transform.rotation = targetPosition.localRotation;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            gameObject.SetActive(false);
        }
    }

}
