using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public SpriteRenderer[] sprite;
    public Color spriteColor, spriteColor2;
    public TMPro.TextMeshPro text;
    public Collider col;

    public void activate()
    {
        col.enabled = true;
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite[i].color = spriteColor;
        }
        text.gameObject.SetActive(true);
    }

    public void deactivate()
    {
        col.enabled = false;
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite[i].color = spriteColor2;
        }
        text.gameObject.SetActive(false);
    }

}
