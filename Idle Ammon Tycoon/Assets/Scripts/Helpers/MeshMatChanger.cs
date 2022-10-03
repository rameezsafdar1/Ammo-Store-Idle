using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshMatChanger : MonoBehaviour
{
    public Color col;
    public Renderer[] bodyPart;
    protected MaterialPropertyBlock[] propertyBlock;

    private void Start()
    {
        propertyBlock = new MaterialPropertyBlock[bodyPart.Length];

        for (int i = 0; i < propertyBlock.Length; i++)
        {
            propertyBlock[i] = new MaterialPropertyBlock();
            bodyPart[i].GetPropertyBlock(propertyBlock[i]);
        }
    }

    public void changeColor()
    {
        for (int i = 0; i < propertyBlock.Length; i++)
        {
            propertyBlock[i].SetColor("_Color", col);
            bodyPart[i].SetPropertyBlock(propertyBlock[i]);
        }
    }
}
