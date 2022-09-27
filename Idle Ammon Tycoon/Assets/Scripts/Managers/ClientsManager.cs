using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles contract clients for mercenaries
public class ClientsManager : BaseClientManager
{
    public BattleStationHelper battlestation;
    public List<Hostage> HostagesPool = new List<Hostage>();
    private int currentHostage;
    public Transform hostageInstPoint, waitArea;

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
        clientsEngaged[0].tag = "Client";
        clientsEngaged[0].consumed = true;
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
