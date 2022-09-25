using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public MaterialPropertyBlock propertyBlock;
    public Renderer bodyPart;
    public Color col;
    private void Start()
    {
        propertyBlock = new MaterialPropertyBlock();
    }

    private void Update()
    {
        propertyBlock.SetColor("_EmissionColor", col);
        bodyPart.SetPropertyBlock(propertyBlock);
    }
}
