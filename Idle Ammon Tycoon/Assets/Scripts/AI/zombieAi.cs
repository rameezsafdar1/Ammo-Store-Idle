using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieAi : BaseAIProperties
{
    private void Update()
    {
        if (state == bodyStates.idle)
        {
            tempPatrolTime += Time.deltaTime;

            if (tempPatrolTime >= waitToPatrol)
            {
                Vector3 randomPos = (Random.insideUnitSphere * 10) + agent.transform.position;
                NavMeshHit navhit;
                agent.FindClosestEdge(out navhit);
                agent.SetDestination(randomPos);
            }

        }
    }

}
