using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class playerStats : MonoBehaviour, iDamagable
{
    public float health;
    private float maxHealth;
    public float damage;
    public Image healthBar;
    public UnityEvent onDeadEvent;
    private float tempTime;

    private void Start()
    {
        //health += saveManager.Instance.loadCustomFloats("additionalHealth");
        maxHealth = health;
    }

    public void takeDamage(float damage, Transform source)
    {
        health -= damage;

        float fillval = health / maxHealth;
        fillval = Mathf.Clamp(fillval, 0.2f, 1f);

        healthBar.fillAmount = fillval;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            if (onDeadEvent != null)
            {
                onDeadEvent.Invoke();
            }           
        }

    }

    public void increaseHealth()
    {
        if (saveManager.Instance.loadCash() >= 100 && health < maxHealth)
        {
            saveManager.Instance.addCash(-100);
            saveManager.Instance.savePermanentGems();

            health += health;

            if (health > maxHealth)
            {
                health = maxHealth;
            }

            float fillval = health / maxHealth;
            fillval = Mathf.Clamp(fillval, 0.2f, 1f);

            healthBar.fillAmount = fillval;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            tempTime += Time.deltaTime;

            if (tempTime >= 0.5f)
            {
                takeDamage(other.GetComponent<EnemyStats>().damage, transform);
                tempTime = 0;
            }

        }
    }

}
