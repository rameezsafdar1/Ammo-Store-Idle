using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieAi : BaseAIProperties
{
    private void Update()
    {
        anim.SetFloat("Velocity", agent.velocity.magnitude);
        if (state == bodyStates.idle)
        {
            tempPatrolTime += Time.deltaTime;

            if (tempPatrolTime >= waitToPatrol)
            {
                agent.SetDestination(RandomNavmeshLocation(10));
                state = bodyStates.patrol;
                tempPatrolTime = 0;
            }
        }

        if (state == bodyStates.patrol)
        {
            if (agent.velocity.magnitude <= 0.2f)
            {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                agent.ResetPath();
                state = bodyStates.idle;
            }
        }

    }

}
