using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformSetter : MonoBehaviour
{
    public CharacterController controller;
    public void setPosRot(Transform newPosition)
    {
        if (controller != null)
        {
            controller.enabled = false;
        }
        transform.position = newPosition.position;
        transform.rotation = newPosition.rotation;
        if (controller != null)
        {
            controller.enabled = true;
        }
    }
}
