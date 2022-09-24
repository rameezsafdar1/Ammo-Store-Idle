using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class BaseClientProperties : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform targetPosition;
    public Image taskImage, fillImage, waitImage;
    public float accuracy;
    public Animator anim;

    public virtual void Update()
    {
        anim.SetFloat("Velocity", Agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HelpDesk")
        {
            taskImage.transform.parent.gameObject.SetActive(true);
        }
    }

}
