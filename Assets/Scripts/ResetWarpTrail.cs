using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWarpTrail : MonoBehaviour
{
    [SerializeField]
    private float defaultWarpTrailTime;
    [SerializeField]
    private TrailRenderer trailRenderer;

    public void ClearWarpTrail()
    {
        trailRenderer.time = 0f;
        trailRenderer.Clear(); 
        trailRenderer.enabled = false;
        InitializeWarpTrailComponent();

    }

    private void InitializeWarpTrailComponent()
    {
        trailRenderer.time = defaultWarpTrailTime;
        trailRenderer.enabled = true;
		Debug.Log("Trail очищен");
    }


}
