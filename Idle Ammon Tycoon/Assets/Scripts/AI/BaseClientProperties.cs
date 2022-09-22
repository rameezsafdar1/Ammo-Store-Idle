using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BaseClientProperties : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform targetPosition;
    public Sprite[] taskSprites;
    public Image taskImage;
}
