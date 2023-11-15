using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public GameObject[] persistenceObjects;

    private void Awake()
    {
        for (int index = 0; index < persistenceObjects.Length; index++)
            DontDestroyOnLoad(persistenceObjects[index]);
    }
}
