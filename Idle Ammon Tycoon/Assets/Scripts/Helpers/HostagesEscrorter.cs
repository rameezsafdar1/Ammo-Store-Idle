using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostagesEscrorter : MonoBehaviour
{
    public ClientsManager CM;
    private List<Hostage> hostages = new List<Hostage>();
    private BaseClientProperties Client;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hostage")
        {
            hostages.Add(other.GetComponent<Hostage>());
            EffectsManager.Instance.hostagesFreed--;

            if (EffectsManager.Instance.hostagesFreed <= 0)
            {
                EffectsManager.Instance.hostagesFreed = 0;
                for (int i = 0; i < hostages.Count; i++)
                {
                    hostages[i].agent.SetDestination(CM.endPos.position);
                }
                Client.Agent.SetDestination(CM.endPos.position);
            }

        }

        if (other.tag == "Client")
        {
            Client = other.GetComponent<BaseClientProperties>();
        }
    }

}
