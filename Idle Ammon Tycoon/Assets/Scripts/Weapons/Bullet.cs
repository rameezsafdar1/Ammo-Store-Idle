using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public playerStats Parent;
    public float speed;
    public Rigidbody rb;
    private float tempTime;
    [HideInInspector]
    public Transform target;
    public GameObject impactparticle;
    public TextMeshPro damageText;

    private void OnEnable()
    {
        rb.isKinematic = false;        
        damageText.text = Parent.damage.ToString();
        impactparticle.transform.parent = this.transform;
        impactparticle.transform.localPosition = Vector3.zero;

        if (target != null)
        {
            Vector3 direction = (target.position - transform.position);
            rb.AddForce(direction.normalized * speed, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }          
    }

    private void Update()
    {
        tempTime += Time.deltaTime;

        if (tempTime >= 2f)
        {
            tempTime = 0;
            impactparticle.transform.parent = EffectsManager.Instance.instParent;
            impactparticle.SetActive(true);
            rb.isKinematic = true;
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            rb.isKinematic = true;
            CinemachineShake.Instance.ShakeCamera(2, 0.1f);
            Vibration.Vibrate(6);
            impactparticle.transform.parent = EffectsManager.Instance.instParent;
            damageText.transform.parent.gameObject.SetActive(true);
            impactparticle.SetActive(true);
            iDamagable damager = other.GetComponent<iDamagable>();
            if (damager != null)
            {
                damager.takeDamage(Parent.damage, transform);
            }
            gameObject.SetActive(false);
        }
    }

}
