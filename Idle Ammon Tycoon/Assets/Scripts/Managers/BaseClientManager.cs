using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseClientManager : MonoBehaviour
{
    [Range(0.3f, 10)]
    public float clientCoolDown;
    public int maxClientAvaialable;
    public List<BaseClientProperties> clientsPool = new List<BaseClientProperties>();
    [HideInInspector]
    public List<BaseClientProperties> clientsEngaged = new List<BaseClientProperties>();
    public List<Transform> destinationPoints = new List<Transform>();    
    [HideInInspector]
    public float tempTime;
    protected int currentClient, currentDestination;
    public Transform startPos, endPos;

    private void Update()
    {
        if (maxClientAvaialable > 0)
        {
            if (currentClient < destinationPoints.Count && clientsEngaged.Count < destinationPoints.Count)
            {
                tempTime += Time.deltaTime;

                if (tempTime >= clientCoolDown)
                {
                    if (maxClientAvaialable < 999)
                    {
                        maxClientAvaialable--;
                    }

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
    }

    public void changeClientsNumber(int x)
    {
        maxClientAvaialable = x;
    }

    public virtual void clientDealt()
    {
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
}
