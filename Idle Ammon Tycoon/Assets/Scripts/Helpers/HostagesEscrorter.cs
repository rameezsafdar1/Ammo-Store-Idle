using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostagesEscrorter : MonoBehaviour
{
    public ClientsManager CM;
    private List<Hostage> hostages = new List<Hostage>();
    private BaseClientProperties Client;
    public GameObject particles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hostage")
        {
            hostages.Add(other.GetComponent<Hostage>());
            EffectsManager.Instance.hostagesFreed--;

            if (EffectsManager.Instance.hostagesFreed <= 0)
            {
                StartCoroutine(wait());
            }

        }

        if (other.tag == "Client")
        {
            Client = other.GetComponent<BaseClientProperties>();
        }
    }

    private IEnumerator wait()
    {
        particles.SetActive(true);
        yield return new WaitForSeconds(2f); 
        EffectsManager.Instance.hostagesFreed = 0;
        for (int i = 0; i < hostages.Count; i++)
        {
            hostages[i].resetFollows();
            hostages[i].agent.SetDestination(CM.endPos.position);
        }
        Client.Agent.SetDestination(CM.endPos.position);
    }


}
