using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{    
    [SerializeField] private GameObject[] eventsObject;
    [SerializeField] private GameObject[] monitors;

    private int delay;
    private Event current;

    void Awake()
    {
        StartCoroutine(TimerEvent());
    }

    public IEnumerator TimerEvent()
    {
        int chance = Random.Range(0, 100);
        int monitorRNG = Random.Range(0, monitors.Length);

        switch (chance)
        {
            case >= 98: // 98-99 : 2
                if (!current.Equals(Event.UFO))
                {
                    current = Event.UFO;
                    Instantiate(eventsObject[0]);
                }
                break;
            case >= 92: // 92-97 : 6
                if (!current.Equals(Event.SHADOW))
                {
                    current = Event.SHADOW;
                    Instantiate(eventsObject[1]);
                }
                break;
            case >= 80: // 80-91 : 12
                if (monitors[monitorRNG].GetComponent<MovementEvent>() == null)
                {
                    current = Event.MOVEMENT;
                    monitors[monitorRNG].AddComponent<MovementEvent>();
                }
                break;
            case >= 62: // 62-79 : 18

                if (monitors[monitorRNG].GetComponent<CameraEvent>() == null)
                {
                    current = Event.CAMERA;
                    monitors[monitorRNG].AddComponent<CameraEvent>();
                }

                break;
            case >= 0:  // 0-61 : 62
                current = Event.NONE;
                break;            
        }

        delay = 1;//Random.Range(5, 30); // 0.25min to 1.0min

        Debug.Log($"Current: {current}, Delay: {delay}");

        yield return new WaitForSeconds(delay);

        StartCoroutine(TimerEvent());
    }

    public IEnumerator TriggerEvent()
    {
        yield return null;
    }

    public IEnumerator UniqueEvent()
    {
        yield return null;
    }
}
