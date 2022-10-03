using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerHelper))]
[RequireComponent(typeof(NavMeshAgent))]
public class MercenaryWorker : MonoBehaviour
{
    public BattleStationHelper stationPoint;
    [HideInInspector]
    public Transform collectionPoint;
    public Animator anim;
    private PlayerHelper helper;
    private NavMeshAgent agent;

    private void OnEnable()
    {
        helper = GetComponent<PlayerHelper>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2;
        agent.SetDestination(stationPoint.transform.position);
        helper.killContractSigned = true;
    }

    private void Update()
    {
        anim.SetFloat("Velocity", agent.velocity.magnitude);

        if (Vector3.Distance(transform.position, stationPoint.transform.position) <= agent.stoppingDistance)
        {
            stationPoint.hasWorker = true;
            transform.rotation = stationPoint.transform.localRotation;

            if (!stationPoint.isBusy)
            {
                Debug.Log("I can take over");
            }
        }
    }
}
