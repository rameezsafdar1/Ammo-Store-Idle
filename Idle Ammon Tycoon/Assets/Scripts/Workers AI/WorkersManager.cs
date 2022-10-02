using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkersManager : MonoBehaviour
{
    [Header("Weapon workers")]
    public GunWorker[] weaponWorkers;
    public List<WeaponStationHelper> weaponStations = new List<WeaponStationHelper>();
    private List<WeaponStationHelper> removableSlots = new List<WeaponStationHelper>();
    private int unlockedWeaponWorker;
    public Button workerButton, mechanicButton;

    private void OnEnable()
    {
        clearStations();
        if (weaponStations.Count > 1)
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
        if (saveManager.Instance.loadCash() >= 100)
        {
            saveManager.Instance.addCash(-100);
            saveManager.Instance.savePermanentGems();
            weaponWorkers[unlockedWeaponWorker].stationPoint = weaponStations[unlockedWeaponWorker];
            weaponWorkers[unlockedWeaponWorker].collectionPoint = weaponStations[unlockedWeaponWorker].collectionPoint;
            weaponWorkers[unlockedWeaponWorker].gameObject.SetActive(true);
            weaponStations[unlockedWeaponWorker].hasWorker = true;
            unlockedWeaponWorker++;

            if (unlockedWeaponWorker >= weaponWorkers.Length)
            {
                unlockedWeaponWorker = 0;
                workerButton.interactable = false;
            }
        }
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
