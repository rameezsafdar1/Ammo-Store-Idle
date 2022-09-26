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
    public GameObject happyEmojis;
    public string[] contractDetails;

    public virtual void Update()
    {
        anim.SetFloat("Velocity", Agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HelpDesk")
        {
            taskImage.gameObject.SetActive(true);
        }
    }

    public void contractOver()
    {
        anim.SetTrigger("Cheer");
        happyEmojis.SetActive(true);
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        Agent.SetDestination(finalPosition.position);
    }

}
