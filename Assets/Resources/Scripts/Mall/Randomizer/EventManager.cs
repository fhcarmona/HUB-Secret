using FMOD.Studio;
using RMS;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{    
    [SerializeField] private GameObject[] eventsObject;
    [SerializeField] private GameObject[] monitors;
    [SerializeField] private TextMeshProUGUI eventText;

    private int delay;    
    private const string eventDescription = "Evento Atual";
    private const string playerTag = "Player";

    public static Event current;
    public static bool isPlayerInSecurityRoom;

    public EventInstance eventInstance { get; private set; }

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(5);

        StartCoroutine(TimerEvent());
    }

    public IEnumerator TimerEvent()
    {
        int chance = Random.Range(0, 100);
        int monitorRNG = Random.Range(0, monitors.Length);

        yield return new WaitWhile(() => DataPersistenceSystem.playerModel.isNewGame);

        eventText.text = null;

        switch (chance)
        {
            case >= 98: // 98-99 : 2
                if (!current.Equals(Event.UFO) && isPlayerInSecurityRoom)
                {
                    Instantiate(eventsObject[0]);
                    eventText.text = $"{eventDescription} -> {current}";
                }
                break;
            case >= 92: // 92-97 : 6
                if (!current.Equals(Event.SHADOW) && isPlayerInSecurityRoom)
                {
                    Instantiate(eventsObject[1]);
                    eventText.text = $"{eventDescription} -> {current}";
                }
                break;
            case >= 80: // 80-91 : 12
                if (monitors[monitorRNG].GetComponent<MovementEvent>() == null && !current.Equals(Event.MOVEMENT))
                {
                    monitors[monitorRNG].AddComponent<MovementEvent>();
                    eventText.text = $"{eventDescription} -> {current}";
                }
                break;
            case >= 62: // 62-79 : 18

                if (monitors[monitorRNG].GetComponent<CameraEvent>() == null && !current.Equals(Event.CAMERA))
                {
                    monitors[monitorRNG].AddComponent<CameraEvent>();
                    eventText.text = $"{eventDescription} -> {current}";
                }

                break;
            case >= 0:  // 0-61 : 62
                current = Event.NONE;
                break;            
        }

        delay = Random.Range(2, 6); // 0.25min to 1.0min

        if(eventText.text != null)
            eventText.gameObject.SetActive(false);

        yield return new WaitUntil(() => current == Event.NONE);

        eventText.gameObject.SetActive(false);

        yield return new WaitForSeconds(delay);

        StartCoroutine(TimerEvent());
    }

    public IEnumerator TriggerEvent(int triggerEvent, bool condition)
    {
        int chance = Random.Range(0, 100);

        // Blackhole
        if (triggerEvent == 1 && (chance >= 95 || !condition))
        {
            eventsObject[2].SetActive(condition);

            if (condition)
                eventInstance = AudioManager.instance.PlayOneShot(FMODEvents.instance.blackhole, eventsObject[2].transform.position, null, -1);                
        }

        yield return null;
    }

    public IEnumerator UniqueEvent()
    {
        yield return null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            isPlayerInSecurityRoom = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
            isPlayerInSecurityRoom = false;
        }
    }
}
