using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieAi : BaseAIProperties
{
    private float patrolWait;

    private void Update()
    {
        colorChangeForDamage();
        if (health > 0)
        {
            anim.SetFloat("Velocity", agent.velocity.magnitude);

            if (state == bodyStates.attack)
            {

            }

            else
            {
                if (state == bodyStates.idle)
                {
                    tempPatrolTime += Time.deltaTime;

                    if (tempPatrolTime >= waitToPatrol)
                    {
                        patrolWait = 0;
                        agent.SetDestination(RandomNavmeshLocation(40));
                        state = bodyStates.patrol;
                        tempPatrolTime = 0;
                    }
                }

                if (state == bodyStates.patrol)
                {
                    patrolWait += Time.deltaTime;
                    if (patrolWait >= 1f)
                    {
                        if (agent.remainingDistance <= agent.stoppingDistance)
                        {
                            agent.isStopped = true;
                            agent.velocity = Vector3.zero;
                            agent.ResetPath();
                            state = bodyStates.idle;
                        }
                    }
                }

            }
        }
    }

}
