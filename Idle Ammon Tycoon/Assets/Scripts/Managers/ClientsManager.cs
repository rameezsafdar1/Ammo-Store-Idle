using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClientsManager : MonoBehaviour
{
    [Header("==> Contract Clients Settings")]
    public BattleStationHelper battlestation;
    [Range(0.3f, 10)]
    public float clientCoolDown;
    public int maxClientAvaialable;
    public List<BaseClientProperties> clientsPool = new List<BaseClientProperties>();
    private List<BaseClientProperties> clientsEngaged = new List<BaseClientProperties>();
    public List<Transform> destinationPoints = new List<Transform>();
    public List<Hostage> HostagesPool = new List<Hostage>();
    [HideInInspector]
    public float tempTime;    
    private int currentClient, currentDestination, currentHostage;
    public Transform startPos, waitArea, hostageInstPoint;    

    private void Update()
    {
        if (currentClient < maxClientAvaialable && clientsEngaged.Count < destinationPoints.Count)
        {
            tempTime += Time.deltaTime;

            if (tempTime >= clientCoolDown)
            {
                clientsPool[currentClient].transform.position = startPos.position;
                clientsPool[currentClient].targetPosition = destinationPoints[currentDestination];
                clientsPool[currentClient].gameObject.SetActive(true);
                clientsEngaged.Add(clientsPool[currentClient]);
                clientsPool.Remove(clientsPool[currentClient]);
                currentClient++;
                currentDestination++;

                if (currentDestination >= destinationPoints.Count)
                {
                    currentDestination = destinationPoints.Count;
                }

                if (currentClient >= clientsPool.Count)
                {
                    currentClient = 0;
                }

                tempTime = 0;
            }
        }
    }

    public void clientDealt()
    {
        battlestation.station.taskImage = null;
        clientsPool.Add(clientsEngaged[0]);
        clientsEngaged[0].Agent.SetDestination(clientsEngaged[0].finalPosition.position);
        clientsEngaged[0].taskImage.gameObject.SetActive(false);

        for (int i = clientsEngaged.Count - 1; i > 0; i--)
        {
            clientsEngaged[i].targetPosition = clientsEngaged[i - 1].targetPosition;            
        }

        for (int i = 1; i < clientsEngaged.Count; i++)
        {
            clientsEngaged[i].Agent.SetDestination(clientsEngaged[i].targetPosition.position);
        }

        clientsEngaged.RemoveAt(0);
        currentDestination--;

        if (currentDestination < 0)
        {
            currentDestination = 0;
        }

    }

    public void clientAccepted()
    {
        battlestation.station.taskImage = null;
        clientsEngaged[0].Agent.SetDestination(waitArea.position);
        clientsEngaged[0].taskImage.gameObject.SetActive(false);

        for (int i = clientsEngaged.Count - 1; i > 0; i--)
        {
            clientsEngaged[i].targetPosition = clientsEngaged[i - 1].targetPosition;
        }

        for (int i = 1; i < clientsEngaged.Count; i++)
        {
            clientsEngaged[i].Agent.SetDestination(clientsEngaged[i].targetPosition.position);
        }

        clientsEngaged.RemoveAt(0);
        currentDestination--;

        if (currentDestination < 0)
        {
            currentDestination = 0;
        }

    }

    public void contractCompleted()
    {

    }

    public void callHostages()
    {
        for (int i = 0; i < EffectsManager.Instance.hostagesFreed; i++)
        {
            HostagesPool[currentHostage].transform.position = hostageInstPoint.position;
            HostagesPool[currentHostage].startFollowToEnd(waitArea);
            HostagesPool[currentHostage].gameObject.SetActive(true);
            HostagesPool[currentHostage].anim.SetTrigger("Cheer");
            currentHostage++;
            if (currentHostage >= HostagesPool.Count)
            {
                currentHostage = 0;
            }
        }
    }


}
