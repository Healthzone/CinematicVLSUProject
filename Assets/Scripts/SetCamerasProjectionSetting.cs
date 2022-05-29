using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamerasProjectionSetting : MonoBehaviour
{
    [SerializeField]
    private Camera[] cameras;
    void Start()
    {
        foreach (var cam in cameras)
        {
            cam.gateFit = Camera.GateFitMode.Vertical;
        }   
    }

    
}
