using FMOD.Studio;
using RMS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEvent : MonoBehaviour
{
    private Light movementIndicator;

    public void Awake()
    {
        movementIndicator = GetComponentInChildren<Light>();
        EventManager.current = Event.MOVEMENT;
    }

    public void Start()
    {
        StartCoroutine(LightSequence());
    }

    public void OnDestroy()
    {
        EventManager.current = Event.NONE;
    }

    public IEnumerator LightSequence()
    {
        EventInstance commEvent;

        for (int index = 0; index < 5; index++)
        {
            movementIndicator.enabled = true;

            commEvent = AudioManager.instance.PlayOneShot(FMODEvents.instance.beep, transform.position, null, -1);
            commEvent.getPlaybackState(out PLAYBACK_STATE state);

            while (state != PLAYBACK_STATE.STOPPED)
            {
                commEvent.getPlaybackState(out state);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitUntil(() => state == PLAYBACK_STATE.STOPPED);

            movementIndicator.enabled = false;

            yield return new WaitForSeconds(1);
        }

        Destroy(this);
    }    
}
