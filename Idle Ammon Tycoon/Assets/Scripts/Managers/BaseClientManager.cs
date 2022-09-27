using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseClientManager : MonoBehaviour
{
    [Range(0.3f, 10)]
    public float clientCoolDown;
    public int maxClientAvaialable;
    public List<BaseClientProperties> clientsPool = new List<BaseClientProperties>();
    protected List<BaseClientProperties> clientsEngaged = new List<BaseClientProperties>();
    public List<Transform> destinationPoints = new List<Transform>();    
    [HideInInspector]
    public float tempTime;
    protected int currentClient, currentDestination;
    public Transform startPos, endPos;

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

    public void changeClientsNumber(int x)
    {
        maxClientAvaialable = x;
    }
}
