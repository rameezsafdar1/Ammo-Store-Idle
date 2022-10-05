using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assaultRifle : baseGuns
{
    private bool inShootingState;

    public override void shootingBehavior()
    {
        if (inShootingState)
        {
            tempShootTime = shootingFrequency;
        }
        else
        {
            inShootingState = true;
            StartCoroutine(shootWithDelay());
        }

    }

    private IEnumerator shootWithDelay()
    {
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.15f);
            if (Fov.detectedObjects.Count > 0)
            {
                anim.SetBool("Shoot", true);
                bullets[currentBullet].target = closestEnemy;
                bullets[currentBullet].transform.position = instPoint.position;
                bullets[currentBullet].gameObject.SetActive(true);
                currentBullet++;
                if (currentBullet >= bullets.Length)
                {
                    currentBullet = 0;
                }
            }
        }
        inShootingState = false;
        tempShootTime = 0;
    }

}
