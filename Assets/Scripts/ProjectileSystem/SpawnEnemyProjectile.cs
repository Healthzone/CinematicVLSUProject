using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject ProjectilePrefab;

    [SerializeField]
    private GameObject FirePoint;

    [SerializeField]
    private GameObject Ship;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float delay;

    [SerializeField]
    private ParticleSystem muzzle;

    [SerializeField]
    private GameObject explosionPrefab;


    public void SpawnProjectilePrefab()
    {

        Debug.Log("Spawned");
        GameObject spawnedPrefab = Instantiate(ProjectilePrefab, FirePoint.transform.position, Quaternion.Euler(Ship.transform.localEulerAngles.x + 90f, Ship.transform.localEulerAngles.y, Ship.transform.localEulerAngles.z));
        muzzle.Play();
        spawnedPrefab.GetComponent<Rigidbody>().AddForce(-FirePoint.transform.right * speed);
        StartCoroutine(DeleteProjectile(spawnedPrefab));
    }

    IEnumerator DeleteProjectile(GameObject prefab)
    {
        yield return new WaitForSeconds(delay);
        Destroy(prefab);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
        
    }



    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnProjectilePrefab();
        }


    }
}
