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
    public List<Transform> destinationPoints = new List<Transform>();
    public Sprite contractSprite;   
    [HideInInspector]
    public float tempTime;
    private int currentClient, currentDestination;
    public Transform startPos;
    private void Update()
    {
        if (currentClient < maxClientAvaialable)
        {
            tempTime += Time.deltaTime;

            if (tempTime >= clientCoolDown)
            {
                clientsPool[currentClient].transform.position = startPos.position;
                clientsPool[currentClient].targetPosition = destinationPoints[currentDestination];
                clientsPool[currentClient].gameObject.SetActive(true);
                clientsPool.Remove(clientsPool[currentClient]);
                currentClient++;
                currentDestination++;

                if (currentDestination >= destinationPoints.Count)
                {
                    currentDestination = 0;
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

    }

}
