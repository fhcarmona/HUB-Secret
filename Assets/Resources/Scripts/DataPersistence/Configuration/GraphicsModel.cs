using System;
using UnityEngine;

namespace RMS
{
    [Serializable]
    public class GraphicsModel
    {
        public int resolution { get; set; }
        public int textureQuality { get; set; }
        public int displayOutput { get; set; }
        public int windowMode { get; set; }
        public bool vSync { get; set; }

        public GraphicsModel()
        {
            resolution = 0;
            textureQuality = 0;
            displayOutput = 0;
            windowMode = 0;
            vSync = false;
        }

        public void Log()
        {
            Debug.Log($"GraphicsModel -> Resolution[{resolution}], TextureQuality[{textureQuality}], DisplayOutput[{displayOutput}], WindowMode[{windowMode}], VSync[{vSync}]");
        }
    }
}