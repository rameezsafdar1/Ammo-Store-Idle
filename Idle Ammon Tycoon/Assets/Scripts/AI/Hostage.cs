using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hostage : MonoBehaviour
{
    private bool followPlayer, followEnd;
    public NavMeshAgent agent;
    public Animator anim;
    private Transform endpos;

    private void Update()
    {
        if (followPlayer)
        {
            agent.SetDestination(EffectsManager.Instance.Player.transform.position);
            anim.SetFloat("Velocity", agent.velocity.magnitude);
        }

        if (followEnd)
        {
            agent.SetDestination(endpos.position);
            anim.SetFloat("Velocity", agent.velocity.magnitude);
        }

    }

    public void startFollow()
    {
        EffectsManager.Instance.hostagesFreed++;
        agent.enabled = true;
        followPlayer = true;
    }

    public void startFollowToEnd(Transform pos)
    {
        endpos = pos;
        agent.enabled = true;
        followEnd = true;
    }
}
