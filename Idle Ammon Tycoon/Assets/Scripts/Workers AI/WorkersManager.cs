using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkersManager : MonoBehaviour
{

    public int workerPrice, shooterPrice;
    public TextMeshProUGUI priceTextWorker, priceTextShooter;

    [Header("Weapon workers")]
    public List<GunWorker> weaponWorkers = new List<GunWorker>();
    [HideInInspector]
    public List<WeaponStationHelper> weaponStations = new List<WeaponStationHelper>();
    private List<WeaponStationHelper> removableSlots = new List<WeaponStationHelper>();
    private List<WeaponStationHelper> removableSlotstwo = new List<WeaponStationHelper>();    
    public Button workerButton, mechanicButton;

    private void OnEnable()
    {
        clearStations();
        priceTextWorker.text = workerPrice.ToString();
        priceTextShooter.text = shooterPrice.ToString();
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
        if (saveManager.Instance.loadCash() >= workerPrice && weaponWorkers.Count > 0 && weaponStations.Count >  0)
        {
            saveManager.Instance.addCash(-workerPrice);
            saveManager.Instance.savePermanentGems();
            weaponWorkers[0].stationPoint = weaponStations[0];
            weaponWorkers[0].collectionPoint = weaponStations[0].collectionPoint;
            weaponWorkers[0].gameObject.SetActive(true);
            weaponStations[0].hasWorker = true;
            weaponWorkers.RemoveAt(0);
            weaponStations.RemoveAt(0);
            workerPrice += 100;
            priceTextWorker.text = workerPrice.ToString();
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


    private void clearStations()
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
