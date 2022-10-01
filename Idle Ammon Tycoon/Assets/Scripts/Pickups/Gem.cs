using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [HideInInspector]
    public Transform realParent;

    public void addGems()
    {
        transform.parent = realParent;
        transform.localPosition = new Vector3(0, 2, 0);
        saveManager.Instance.addGem();
        gameObject.SetActive(false);
    }
}
