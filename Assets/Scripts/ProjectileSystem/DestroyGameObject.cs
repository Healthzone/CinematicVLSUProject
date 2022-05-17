using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "123");
        ContactPoint contact = collision.GetContact(0);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(explosionPrefab, position, rotation);
        Destroy(gameObject);
    }
}
