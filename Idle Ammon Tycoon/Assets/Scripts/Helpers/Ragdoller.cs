using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ragdoller : MonoBehaviour
{
    public BaseAIProperties baseController;
    private Collider[] ragCols;
    private Rigidbody[] ragRigids;
    public Animator anim;
    public UnityEvent onRagdoll;

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
        ragCols[1].enabled = true;
    }

    public void turnOnRagDoll(float force, Vector3 direction)
    {
        anim.enabled = false;
        for (int i = 0; i < ragCols.Length; i++)
        {
            ragCols[i].enabled = true;
        }
        ragCols[0].enabled = false;
        for (int i = 0; i < ragRigids.Length; i++)
        {
            ragRigids[i].isKinematic = false;
            ragRigids[i].AddForce(transform.up * 2, ForceMode.Impulse);
            ragRigids[i].AddForce(direction.normalized * force, ForceMode.Impulse);
        }

        if (onRagdoll != null)
        {
            onRagdoll.Invoke();
        }

    }

}
