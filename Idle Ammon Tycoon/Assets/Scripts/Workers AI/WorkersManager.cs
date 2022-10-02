using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkersManager : MonoBehaviour
{
    [Header("Weapon workers")]
    public List<GunWorker> weaponWorkers = new List<GunWorker>();
    public List<WeaponStationHelper> weaponStations = new List<WeaponStationHelper>();
    private List<WeaponStationHelper> removableSlots = new List<WeaponStationHelper>();
    private List<WeaponStationHelper> removableSlotstwo = new List<WeaponStationHelper>();    
    public Button workerButton, mechanicButton;

    private void OnEnable()
    {
        clearStations();
        if (weaponStations.Count > 0)
        {
            workerButton.interactable = true;
        }
        else
        {
            workerButton.interactable = false;
        }
    }

    public void unlockWeaponWorker()
    {
        clearStationswithnoclient();
        if (saveManager.Instance.loadCash() >= 100 && weaponWorkers.Count > 0 && weaponStations.Count >  0)
        {
            saveManager.Instance.addCash(-100);
            saveManager.Instance.savePermanentGems();
            weaponWorkers[0].stationPoint = weaponStations[0];
            weaponWorkers[0].collectionPoint = weaponStations[0].collectionPoint;
            weaponWorkers[0].gameObject.SetActive(true);
            weaponStations[0].hasWorker = true;
            weaponWorkers.RemoveAt(0);
            weaponStations.RemoveAt(0);
            if (weaponWorkers.Count <= 0)
            {
                workerButton.interactable = false;
            }
        }
        else
        {
            workerButton.interactable = false;
        }
    }


    private void clearStationswithnoclient()
    {
        for (int i = 0; i < weaponStations.Count; i++)
        {
            if (weaponStations[i].weaponClient.maxClientAvaialable <= 0)
            {
                removableSlotstwo.Add(weaponStations[i]);
            }
        }

        for (int i = 0; i < removableSlotstwo.Count; i++)
        {
            weaponStations.Remove(removableSlotstwo[i]);
        }
        removableSlotstwo.Clear();
    }


    public void clearStations()
    {
        for (int i = 0; i < weaponStations.Count; i++)
        {
            if (!weaponStations[i].gameObject.activeInHierarchy)
            {
                removableSlots.Add(weaponStations[i]);
            }
        }

        for (int i = 0; i < removableSlots.Count; i++)
        {
            weaponStations.Remove(removableSlots[i]);
        }
        removableSlots.Clear();
    }

}
