using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public int cashCollectionTarget;
    private ActivityManager activityManager;
    public FinishTrigger finishTrigger;
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
    public UnityEvent onLevelTimeComplete;
    private bool dayCompleted;
    public bool targeted;
    private bool worldChange;

    private void Start()
    {
        if (targeted)
        {
            cashCollectionTarget = saveManager.Instance.loadCustomInts("dailyTarget");

            if (cashCollectionTarget < 3)
            {
                cashCollectionTarget = 3;
                saveManager.Instance.saveCustomInts("dailyTarget", cashCollectionTarget);
            }

        }

        setLevel();
    }

    public void stopClientInflux()
    {
        if (!dayCompleted)
        {
            dayCompleted = true;

            //int remainingCustomers = 0;

            //for (int i = 0; i < weapon_manager.Length; i++)
            //{
            //    weapon_manager[i].maxClientAvaialable = 0;
            //    remainingCustomers += weapon_manager[i].clientsEngaged.Count;
            //}

            //for (int i = 0; i < contract_manager.Length; i++)
            //{
            //    contract_manager[i].maxClientAvaialable = 0;
            //    remainingCustomers += contract_manager[i].clientsEngaged.Count;
            //}
            activityManager.callEvent();
            //activityManager.setNewevents(remainingCustomers + 1);
            
        }
    }

    public void permanentClientStop()
    {
        if (!worldChange)
        {


            int remainingCustomers = 0;

            for (int i = 0; i < weapon_manager.Length; i++)
            {
                weapon_manager[i].maxClientAvaialable = 0;
                remainingCustomers += weapon_manager[i].clientsEngaged.Count;
            }

            for (int i = 0; i < contract_manager.Length; i++)
            {
                contract_manager[i].maxClientAvaialable = 0;
                remainingCustomers += contract_manager[i].clientsEngaged.Count;
            }
            activityManager.callEvent();
            activityManager.setNewevents(remainingCustomers + 1);
            worldChange = true;
        }
    }

    private void setLevel()
    {
        saveManager.Instance.levelManager = this;
        saveManager.Instance.cashCollectionTarget = cashCollectionTarget;
        saveManager.Instance.collectedCashInLevel = 0;
        if (cashCollectionTarget > 0)
        {
            saveManager.Instance.dayBarFiller.fillAmount = 0 / cashCollectionTarget;
        }
        activityManager = GetComponent<ActivityManager>();
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

        if (areas.Length > 0)
        {
            combat_manager.battleAreas = new GameObject[areas.Length];
            for (int i = 0; i < combat_manager.battleAreas.Length; i++)
            {
                combat_manager.battleAreas[i] = areas[i];
            }
        }

        if (activityManager != null)
        {
            finishTrigger.activity = activityManager;
            int eventcount = (contract_manager.Length * ContractCustomers) + (weapon_manager.Length * WeaponCustomers);
            activityManager.totalEvents = eventcount;
        }
    }

    public void updateLevel()
    {
        saveManager.Instance.updateDay();
        cashCollectionTarget += 2;
        saveManager.Instance.saveCustomInts("dailyTarget", cashCollectionTarget);
        saveManager.Instance.savePermanentGems();

        if (cashCollectionTarget >= 50)
        {
            cashCollectionTarget = 50;
        }
        dayCompleted = false;
        setLevel();
    }

}
