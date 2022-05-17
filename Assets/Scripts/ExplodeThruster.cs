using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeThruster : MonoBehaviour
{
    private Rigidbody rigidbody;

    [SerializeField]
    private float explosionForce;

    [SerializeField]
    private Transform positionToForce;
    private bool isExploded = false;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isExploded)
        {
            rigidbody.AddExplosionForce(explosionForce, positionToForce.position, 20f);
        }
    }

    public void ExplodeThrusterMethod()
    {
        isExploded = true;
        GetComponent<Animator>().enabled = false;
    }

}
