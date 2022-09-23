using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class BaseClientProperties : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform targetPosition;
    public Image taskImage;
    public float accuracy;
}
