using System;
using UnityEngine;

namespace RMS
{
    [Serializable]
    public class AudioModel
    {
        public float audioVolume { get; set; }
        public float musicVolume { get; set; }
        public int outputDevice { get; set; }

        public AudioModel()
        {
            audioVolume = 1.0f;
            musicVolume = 1.0f;
            outputDevice = 0;
        }

        public void Log()
        {
            Debug.Log($"AudioModel -> AudioVolume[{audioVolume}], MusicVolume[{musicVolume}], OutputDevice[{outputDevice}]");
        }
    }
}