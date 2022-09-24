using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ClientsManager manager;
    public int totalCustomers;
    [Range(0.3f, 10)]
    public float coolDown;


    private void Start()
    {
        manager.maxClientAvaialable = totalCustomers;
        manager.clientCoolDown = coolDown;
        manager.tempTime = coolDown;
    }

}
