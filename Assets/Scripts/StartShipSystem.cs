using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class StartShipSystem : MonoBehaviour
{
    [SerializeField]
    private Material shipMeshRenderer;

    [SerializeField]
    private float rate = 0.02f;
    [SerializeField]
    private float rateOff = 0.5f;

    [SerializeField]
    private float intensityLevel = 2f;
    [SerializeField]
    private float decreasingIntensityLevel = 2f;

    [SerializeField]
    private Color color;

    [SerializeField]
    private Color colorOff;
    void Start()
    {
        shipMeshRenderer.EnableKeyword("_Emission");
        shipMeshRenderer.SetVector("_EmissionColor", new Vector4(0, 0, 0, 0));
    }
    public void StartSetEmissionColorShipCoroutine()
    {
        StartCoroutine(SetEmissionColorShip());
        Debug.Log("Начал");
    }
       public IEnumerator SetEmissionColorShip()
    {
        Debug.Log("Начал");
        float amount = -5f;
        while (amount <= intensityLevel)
        {
            amount += rate;
            shipMeshRenderer.SetVector("_EmissionColor", color*amount);
            yield return new WaitForSeconds(0.15f);
        }
    }

    public void DisableEmissionColor()
    {
        shipMeshRenderer.SetVector("_EmissionColor", Color.black);
    }

}
