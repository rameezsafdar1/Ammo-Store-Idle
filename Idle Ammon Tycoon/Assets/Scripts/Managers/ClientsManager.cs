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
    public Transform[] destinationPoints;
    public Sprite[] taskSprites;
    private float tempTime;
    private int currentClient;
    private void Update()
    {
        if (currentClient < maxClientAvaialable)
        {
            tempTime += Time.deltaTime;

            if (tempTime >= clientCoolDown)
            {



                tempTime = 0;
            }
        }
    }

}
