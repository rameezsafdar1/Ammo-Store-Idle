using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ClientsManager[] contract_manager;
    public int ContractCustomers;
    [Range(0.3f, 10)]
    public float ContractCoolDown;
    public weaponsClientManager[] weapon_manager;
    public int WeaponCustomers;
    [Range(0.3f, 10)]
    public float WeaponCoolDown;

    [Header("Combat Areas")]
    public CombatManager combat_manager;
    public GameObject[] areas;

    private void Start()
    {

        for (int i = 0; i < contract_manager.Length; i++)
        {
            contract_manager[i].maxClientAvaialable = ContractCustomers;
            contract_manager[i].clientCoolDown = ContractCoolDown;
            contract_manager[i].tempTime = ContractCoolDown;
        }

        for (int j = 0; j < weapon_manager.Length; j++)
        {
            weapon_manager[j].maxClientAvaialable = WeaponCustomers;
            weapon_manager[j].clientCoolDown = WeaponCoolDown;
            weapon_manager[j].tempTime = ContractCoolDown;
        }


        combat_manager.battleAreas = new GameObject[areas.Length];
        for (int i = 0; i < combat_manager.battleAreas.Length; i++)
        {
            combat_manager.battleAreas[i] = areas[i];
        }

    }

}
