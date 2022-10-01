using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerHelper))]
[RequireComponent(typeof(NavMeshAgent))]
public class GunWorker : MonoBehaviour
{
    public WeaponStationHelper stationPoint;
    [HideInInspector]
    public Transform collectionPoint;
    public Animator anim;
    private PlayerHelper helper;
    private NavMeshAgent agent;
    private WeaponCorkBoard board;
    private float waitTime;

    private void OnEnable()
    {
        helper = GetComponent<PlayerHelper>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        anim.SetFloat("Velocity", agent.velocity.magnitude);
        if (!helper.gunContractSigned)
        {
            agent.SetDestination(stationPoint.transform.position);
        }

        else
        {
            if (!helper.hasGunForSale)
            {
                agent.SetDestination(collectionPoint.position);
            }
            else
            {
                agent.SetDestination(stationPoint.transform.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WorkerInteractable")
        {
            board = other.GetComponent<WeaponCorkBoard>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "WorkerInteractable" && board != null && !helper.hasGunForSale)
        {
            waitTime += Time.deltaTime;

            if (waitTime >= board.waitTime)
            {
                board.takeGun();
                helper.hasGunForSale = true;
                waitTime = 0;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WorkerInteractable")
        {
            waitTime = 0;
            board = null;
        }
    }

}
