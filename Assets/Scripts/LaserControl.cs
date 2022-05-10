using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public GameObject FirePoint;
    public float MaxLength;
    public GameObject Prefab;
    public LineRenderer laser;
    private bool isActive = false;
    private AudioSource audioSource;
    

    Vector3 getGunPivotPos() => FirePoint.transform.position;
    Vector3 getGunNozzlePos() => getGunPivotPos() + FirePoint.transform.rotation  * (Vector3.up * MaxLength);

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isActive)
        {
            Vector3 p1 = getGunPivotPos();
            Vector3 p2 = getGunNozzlePos();
            laser.SetPosition(0, p1);
            laser.SetPosition(1, p2);
            audioSource.Play();
            laser.enabled = true;

        }
        else
        {
            laser.enabled = false;
            audioSource.Stop();
        }

        if (Input.GetMouseButtonUp(1))
        {


        }
    }

    public void ActivateLaser()
    {
        isActive = !isActive;
    }


  
}
