using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEvent : MonoBehaviour
{
    private Vector3[] respawnPoints =
    {
        new Vector3(12.85f, 3.39f, 0f),
        new Vector3(22.89f, -1.03f, -10.584f),
        new Vector3(-11.7f, -1.1f, -2.76f),
        new Vector3(-1.28f, 3.52f, -15.39f)
    };

    private Vector3[] respawnRotation =
    {
        new Vector3(0, 0, 0),
        new Vector3(0, 0, 0),
        new Vector3(0, -90, 0),
        new Vector3(0, -90, 0)
    };

    public IEnumerator Start()
    {
        int respawnRNG = Random.Range(0, respawnPoints.Length);

        transform.position = respawnPoints[respawnRNG];
        transform.Rotate(respawnRotation[respawnRNG], Space.Self);

        yield return new WaitForSeconds(Random.Range(2, 5));

        Destroy(gameObject);
    }
}
