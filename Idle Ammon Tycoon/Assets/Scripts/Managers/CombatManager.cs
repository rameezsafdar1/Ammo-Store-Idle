using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatManager : MonoBehaviour
{
    public GameObject[] battleAreas;

    public void commenceBattle()
    {
        int x = Random.Range(0, battleAreas.Length);
        battleAreas[x].SetActive(true);
    }

}
