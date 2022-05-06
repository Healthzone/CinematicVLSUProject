using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
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


    public void SpawnProjectilePrefab()
    {

        Debug.Log("Spawned");
        GameObject spawnedPrefab = Instantiate(ProjectilePrefab, FirePoint.transform.position, Quaternion.Euler(Ship.transform.localEulerAngles.x, Ship.transform.localEulerAngles.y, Ship.transform.localEulerAngles.z + 90f));
        muzzle.Play();
        spawnedPrefab.GetComponent<Rigidbody>().AddForce(-FirePoint.transform.right *speed);
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
