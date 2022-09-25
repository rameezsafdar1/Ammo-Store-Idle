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
public abstract class BaseAIProperties : MonoBehaviour, iDamagable
{
    public bodyStates state;
    public Ragdoller ragdoll;
    public float health, accuracy, waitToPatrol;
    protected float tempHealth, tempPatrolTime;
    public GameObject deathParticle, deathReward;
    public Animator anim;
    public NavMeshAgent agent;
    public Transform target;
    protected bool isHit;
    [Header("Meshes")]
    public Renderer[] bodyPart;
    [SerializeField]
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

    public virtual void takeDamage(float damage, Transform source)
    {
        health -= damage;
        colorChangeTime = 0.1f;
        if (health <= 0)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            agent.ResetPath();
            gameObject.layer = 0;
            ragdoll.turnOnRagDoll(50, transform.position - source.position);
        }
    }

}
