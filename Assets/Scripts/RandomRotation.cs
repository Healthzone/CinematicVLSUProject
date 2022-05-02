using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 randomVector3;
    [SerializeField]
    private float delay;
    [SerializeField]
    private float damping = 10f;

    Quaternion rot;

    private void Start()
    {
        gameObject.transform.rotation = Quaternion.identity;
        randomVector3 = new Vector3(Random.Range(10000f, 50000f), Random.Range(10000f, 50000f), Random.Range(10000f, 50000f));
        Vector3 newPos = new Vector3(gameObject.transform.position.x + randomVector3.x, gameObject.transform.position.y + randomVector3.y, gameObject.transform.position.z + randomVector3.z);
        rot = Quaternion.Euler(newPos.x, newPos.y, newPos.z);
        StartCoroutine(StartRotation(rot));
    }


    IEnumerator StartRotation(Quaternion rot)
    {
        
        gameObject.transform.rotation = Quaternion.RotateTowards (gameObject.transform.rotation, rot, Time.deltaTime * damping);
        yield return new WaitForSeconds(delay);
        StartCoroutine(StartRotation(rot));
        yield return null;
    }


}
