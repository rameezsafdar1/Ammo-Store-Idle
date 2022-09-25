using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoller : MonoBehaviour
{
    private Collider[] ragCols;
    private Rigidbody[] ragRigids;
    public Animator anim;    
    private void Start()
    {
        offRagdoll();
    }

    public void offRagdoll()
    {
        ragCols = GetComponentsInChildren<Collider>();
        ragRigids = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < ragCols.Length; i++)
        {
            ragCols[i].enabled = false;
        }
        ragCols[0].enabled = true;

    }

    public void turnOnRagDoll(float force, Vector3 direction)
    {
        anim.enabled = false;
        for (int i = 0; i < ragCols.Length; i++)
        {
            ragCols[i].enabled = true;
        }
        for (int i = 0; i < ragRigids.Length; i++)
        {
            ragRigids[i].isKinematic = false;
            ragRigids[i].AddForce(transform.up * 5, ForceMode.Impulse);
            ragRigids[i].AddForce(direction.normalized * force, ForceMode.Impulse);
        }
    }

}
