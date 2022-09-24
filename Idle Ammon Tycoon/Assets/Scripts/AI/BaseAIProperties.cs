using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum bodyStates
{
    idle,
    patrol,
    attack,
}
public abstract class BaseAIProperties : MonoBehaviour
{
    public bodyStates state;
    public float health, accuracy, waitToPatrol;
    protected float tempHealth, tempPatrolTime;
    public GameObject deathParticle, deathReward;
    public Animator anim;
    public NavMeshAgent agent;
    public Transform target;
    protected bool isHit;
    [Header("Meshes")]
    public Renderer[] bodyPart;
    protected MaterialPropertyBlock[] propertyBlock;
    public Color col;
    protected Color lerpColor;
    protected float colorChangeTime;
    protected Vector3 randomDirection;

    public virtual void Start()
    {
        tempHealth = health;

        propertyBlock = new MaterialPropertyBlock[bodyPart.Length];

        for (int i = 0; i < propertyBlock.Length; i++)
        {
            propertyBlock[i] = new MaterialPropertyBlock();
            bodyPart[i].GetPropertyBlock(propertyBlock[i]);
            bodyPart[i].gameObject.SetActive(true);
        }

    }

    public void hitComplete()
    {
        isHit = false;
        if (agent.enabled)
        {
            agent.isStopped = false;
        }
        anim.SetBool("isHit", false);
    }

    protected void colorChangeForDamage()
    {
        if (colorChangeTime > 0)
        {
            colorChangeTime -= Time.deltaTime;
            lerpColor = Color.Lerp(lerpColor, col, 60 * Time.deltaTime);
        }
        else
        {
            lerpColor = Color.Lerp(lerpColor, Color.black, 60 * Time.deltaTime);
        }

        for (int i = 0; i < propertyBlock.Length; i++)
        {
            propertyBlock[i].SetColor("_EmissionColor", lerpColor);
            bodyPart[i].SetPropertyBlock(propertyBlock[i]);
        }
    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        randomDirection = (Random.insideUnitSphere * radius) + transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
