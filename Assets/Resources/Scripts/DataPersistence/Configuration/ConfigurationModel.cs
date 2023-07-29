using System;

namespace RMS
{
    [Serializable]
    public class ConfigurationModel
    {
        public GraphicsModel graphicsModel { get; set; }
        public AudioModel audioModel { get; set; }
        public ControllerModel controllerModel { get; set; }
        public AccessibilityModel accessibilityModel { get; set; }

        public ConfigurationModel()
        {
            graphicsModel = new GraphicsModel();
            audioModel = new AudioModel();
            controllerModel = new ControllerModel();
            accessibilityModel = new AccessibilityModel();
        }

        public void Log()
        {
            graphicsModel.Log();
            audioModel.Log();
            controllerModel.Log();
            accessibilityModel.Log();
        }
    }
}