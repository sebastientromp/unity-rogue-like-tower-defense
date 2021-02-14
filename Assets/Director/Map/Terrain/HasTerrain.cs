using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasTerrain : MonoBehaviour
{
    public void SetTexture(Texture texture)
    {
        var surface = transform.Find("Surface");
        var renderer = surface.GetComponent<MeshRenderer>();
        var tempMaterial = new Material(renderer.sharedMaterial);
        renderer.sharedMaterial = tempMaterial;
        tempMaterial.SetTexture("_MainTex", texture);
    }
}
