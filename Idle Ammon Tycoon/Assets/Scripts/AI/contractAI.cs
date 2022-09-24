using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contractAI : BaseClientProperties
{
    private void OnEnable()
    {
        Agent.SetDestination(targetPosition.position);
    }

    public override void Update()
    {
        base.Update();

        if (Agent.velocity.magnitude <= 0.1f && targetPosition != null)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
