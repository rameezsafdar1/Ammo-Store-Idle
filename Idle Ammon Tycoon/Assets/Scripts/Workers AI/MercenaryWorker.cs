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
    public float yieldTime;
    private float tempTime;
    public GameObject Gem, Coin;
    public int yieldQuantity;
    public Transform[] dropPositions;
    private int currentDropPosition;
    public GameObject coinAnimation;

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
                tempTime += Time.deltaTime;
                if (tempTime >= yieldTime)
                {
                    for (int i = 0; i < yieldQuantity; i++)
                    {
                        Instantiate(Gem, dropPositions[Random.Range(0, dropPositions.Length)].position, Quaternion.identity);
                        GameObject go = Instantiate(Coin, dropPositions[Random.Range(0, dropPositions.Length)].position, Quaternion.identity);
                        go.GetComponent<Coin>().cashAnimation = coinAnimation;                        
                    }
                    tempTime = 0;
                }
            }
        }
    }
}
