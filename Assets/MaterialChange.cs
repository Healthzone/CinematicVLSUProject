using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MaterialChange : MonoBehaviour
{

    public Renderer ThrustRenderer;
    public Color color;
    void Update()
    {
        ThrustRenderer.material.EnableKeyword("_EMISSION");
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
    }
}
