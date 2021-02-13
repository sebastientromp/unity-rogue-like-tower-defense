using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasTerrain : MonoBehaviour
{
    public void SetTexture(Texture texture)
    {
        var surface = transform.Find("Surface");
        surface.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", texture);
    }
}
