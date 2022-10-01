using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkersManager : MonoBehaviour
{
    [Header("Weapon workers")]
    public GunWorker[] weaponWorkers;
    public WeaponStationHelper[] weaponStations;
    private int unlockedWeaponWorker;

    public void unlockWeaponWorker()
    {
        weaponWorkers[unlockedWeaponWorker].stationPoint = weaponStations[unlockedWeaponWorker];
        weaponWorkers[unlockedWeaponWorker].collectionPoint = weaponStations[unlockedWeaponWorker].collectionPoint;
        weaponWorkers[unlockedWeaponWorker].gameObject.SetActive(true);
        unlockedWeaponWorker++;

        if (unlockedWeaponWorker >= weaponWorkers.Length)
        {
            unlockedWeaponWorker = 0;
        }

    }

}
