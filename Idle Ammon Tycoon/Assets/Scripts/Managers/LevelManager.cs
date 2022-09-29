using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ClientsManager contract_manager;
    public int ContractCustomers;
    [Range(0.3f, 10)]
    public float ContractCoolDown;
    public weaponsClientManager weapon_manager;
    public int WeaponCustomers;
    [Range(0.3f, 10)]
    public float WeaponCoolDown;

    [Header("Combat Areas")]
    public CombatManager combat_manager;
    public GameObject[] areas;

    private void Start()
    {
        contract_manager.maxClientAvaialable = ContractCustomers;
        contract_manager.clientCoolDown = ContractCoolDown;
        contract_manager.tempTime = ContractCoolDown;
        weapon_manager.maxClientAvaialable = WeaponCustomers;
        weapon_manager.clientCoolDown = WeaponCoolDown;
        weapon_manager.tempTime = ContractCoolDown;


        combat_manager.battleAreas = new GameObject[areas.Length];
        for (int i = 0; i < combat_manager.battleAreas.Length; i++)
        {
            combat_manager.battleAreas[i] = areas[i];
        }

    }

}
