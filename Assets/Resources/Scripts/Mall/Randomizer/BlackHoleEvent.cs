using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHoleEvent : MonoBehaviour
{
    public EventManager eventManager;
    public GameObject blackHole;

    private Vector3 originalScale = new Vector3(100, 100, 100);
    private float necessaryTime;
    private float elapsed;

    public void Start()
    {
        necessaryTime = Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(eventManager.TriggerEvent(1, true));
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(eventManager.TriggerEvent(1, false));

        if(eventManager != null)
            eventManager.eventInstance.stop(STOP_MODE.IMMEDIATE);

        blackHole.transform.localScale = originalScale;
        elapsed = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (blackHole.transform.localScale.x < 750)
        {
            elapsed += Time.fixedDeltaTime;

            if (elapsed > necessaryTime)
            {
                blackHole.transform.localScale *= 1.01f;
                elapsed = 0;
            }
        }
        else
        {
            blackHole.transform.localScale *= 1.1f;            
        }
    }
}
