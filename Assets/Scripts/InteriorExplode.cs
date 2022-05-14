using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorExplode : MonoBehaviour
{

    [SerializeField]
    private float explosionForce;

    [SerializeField]
    private float explosionRadius = 1f;

    [SerializeField]
    private float affectedRadius = 1f;

    [SerializeField]
    private Transform depressurizationTransform;
    
    [SerializeField]
    private float speed;

    private Collider[] affectedColliders;
    [SerializeField]
    private float delayBeforeDepressurization;

    private bool isDepressurizated = false;

    void Awake()
    {
        affectedColliders = Physics.OverlapSphere(transform.position, affectedRadius);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, affectedRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(depressurizationTransform.position, depressurizationTransform.position + depressurizationTransform.rotation * (Vector3.up * 10));
    }


    private void FixedUpdate()
    {
        if (isDepressurizated)
        {
            foreach (var collider in affectedColliders)
            {
                Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    Vector3 direction = depressurizationTransform.position - transform.position;
                    rigidbody.AddForce(direction.normalized*speed, ForceMode.Acceleration);
                }
            }
        }
    }

    public void ExplodeStation()
    {
        Debug.Log("Запуск");
        foreach (var collider in affectedColliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                GetComponent<ParticleSystem>().Play();
                rigidbody.isKinematic = false;
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        StartCoroutine(StartDepressurization());
        
    }

    private IEnumerator StartDepressurization()
    {
        yield return new WaitForSeconds(delayBeforeDepressurization);
        isDepressurizated = true;
    }
}
