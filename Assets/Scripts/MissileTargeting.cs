using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTargeting : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float distanceToExplode;
    [SerializeField]
    private GameObject explosionPrefab;

    private bool isMissileLaunched =false;


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + (transform.forward * 10), Time.deltaTime);
        if (isMissileLaunched)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);

            transform.position += transform.forward * Time.deltaTime * moveSpeed;

            if ((target.position - transform.position).magnitude < distanceToExplode)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity,target);

                Destroy(this.gameObject);


            }
        }

    }

    public void LaunchMissile()
    {
        
        isMissileLaunched = true; 

    }


}
