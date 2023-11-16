using FMOD.Studio;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

namespace RMS
{
    public class AudioManager : MonoBehaviour
    {        
        private List<EventInstance> eventInstances;

        public static AudioManager instance { get; private set; }

        private void Awake()
        {
            instance = this;

            eventInstances = new List<EventInstance>();
        }

        public void CleanUp()
        {
            foreach (EventInstance instance in eventInstances)
            {
                instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                instance.release();
            }
        }

        private void OnDestroy()
        {
            CleanUp();
        }

        public void PlayOneShot(EventReference reference, Vector3 worldPosition)
        {
            RuntimeManager.PlayOneShot(reference, worldPosition);
        }

        public void PlayOneShot(EventReference reference, Vector3 worldPosition, string parameterName, float parameterValue)
        {
            EventInstance instance = RuntimeManager.CreateInstance(reference);
            instance.setParameterByName(parameterName, parameterValue);
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(worldPosition));
            instance.start();
            instance.release();
        }

        public EventInstance CreateEventInstance(EventReference reference)
        {
            EventInstance instance = RuntimeManager.CreateInstance(reference);
            eventInstances.Add(instance);
            return instance;
        }

        public EventInstance CreateEventInstance(EventReference reference, Vector3 worldPosition)
        {
            EventInstance instance = RuntimeManager.CreateInstance(reference);
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(worldPosition));
            eventInstances.Add(instance);
            return instance;
        }        
    }
}