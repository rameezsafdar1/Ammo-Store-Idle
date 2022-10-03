using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatManager : MonoBehaviour
{
    public GameObject[] battleAreas;
    [HideInInspector]
    public GameObject Trigger;
    public transformSetter Player;
    public Transform dropPoint;

    public void commenceBattle()
    {
        int x = Random.Range(0, battleAreas.Length);
        battleAreas[x].SetActive(true);
    }

    public void activateDropBackPoint()
    {
        if (Trigger != null)
        {
            Trigger.SetActive(true);
            Player.setPosRot(dropPoint);
        }
    }

}
