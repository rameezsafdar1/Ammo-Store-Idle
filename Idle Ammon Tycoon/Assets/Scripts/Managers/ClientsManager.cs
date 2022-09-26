using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClientsManager : MonoBehaviour
{
    [Header("Contract Clients Settings")]
    [Range(0.3f, 10)]
    public float clientCoolDown;
    public int maxClientAvaialable;
    public List<BaseClientProperties> clientsPool = new List<BaseClientProperties>();
    [SerializeField]
    private List<BaseClientProperties> clientsEngaged = new List<BaseClientProperties>();
    public List<Transform> destinationPoints = new List<Transform>();
    public Sprite contractSprite;   
    [HideInInspector]
    public float tempTime;
    [SerializeField]
    private int currentClient, currentDestination;
    public Transform startPos;
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
        clientsPool.Add(clientsEngaged[0]);        

        for (int i = 1; i < clientsEngaged.Count; i++)
        {
            clientsEngaged[i].Agent.SetDestination(clientsEngaged[i - 1].targetPosition.position);
        }
        clientsEngaged.RemoveAt(0);
        currentDestination--;

        if (currentDestination < 0)
        {
            currentDestination = 0;
        }

    }
}
