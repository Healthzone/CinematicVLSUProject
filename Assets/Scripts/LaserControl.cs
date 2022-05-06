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

    Vector3 getGunPivotPos() => FirePoint.transform.position;
    Vector3 getGunNozzlePos() => getGunPivotPos() + FirePoint.transform.rotation  * (Vector3.up * MaxLength);


    void Update()
    {
        if (true)
        {
            Vector3 p1 = getGunPivotPos();
            Vector3 p2 = getGunNozzlePos();
            laser.SetPosition(0, p1);
            laser.SetPosition(1, p2);
            laser.enabled = true;

        }

        if (Input.GetMouseButtonUp(1))
        {
            laser.enabled = false;

        }
    }


  
}
