using System;
using UnityEngine;

namespace RMS
{
    [Serializable]
    public class AudioModel
    {
        public float masterVolume { get; set; }
        public float effectVolume { get; set; }
        public float musicVolume { get; set; }
        public int outputDevice { get; set; }

        public AudioModel()
        {
            masterVolume = 1.0f;
            effectVolume = 1.0f;
            musicVolume = 1.0f;
            outputDevice = 0;
        }

        public void Log()
        {
            Debug.Log($"AudioModel -> MasterVolume[{masterVolume}], AudioVolume[{effectVolume}], MusicVolume[{musicVolume}], OutputDevice[{outputDevice}]");
        }
    }
}