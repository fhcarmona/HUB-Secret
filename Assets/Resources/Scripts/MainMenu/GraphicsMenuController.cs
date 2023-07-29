using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RMS
{
    public class Graphics : MonoBehaviour
    {
        [Header("Dropdown List")]
        public TMP_Dropdown display;
        public TMP_Dropdown resolution;
        public TMP_Dropdown textureQuality;
        public TMP_Dropdown windowMode;

        [Header("Toggle List")]
        public Toggle vSync;

        private GraphicsModel _graphicsModel;

        public void Start()
        {
            SetConfigurationData();
        }

        public void OnChangeResolution(int dropdownValue)
        {
            _graphicsModel.resolution = dropdownValue;
        }
        public void OnChangeWindowMode(int dropdownValue)
        {
            _graphicsModel.windowMode = dropdownValue;
        }
        public void OnChangeDisplayOutput(int dropdownValue)
        {
            _graphicsModel.displayOutput = dropdownValue;
        }
        public void OnChangeTextureQuality(int dropdownValue)
        {
            _graphicsModel.textureQuality = dropdownValue;
        }
        public void OnChangeVSync(bool isOn)
        {
            _graphicsModel.vSync = isOn;
        }

        public void OnClickSave()
        {
            if (_graphicsModel != null)
                DataPersistenceSystem.configurationModel.graphicsModel = _graphicsModel;
        }

        public void OnClickCancel()
        {
            SetConfigurationData();
        }

        private void SetConfigurationData()
        {
            _graphicsModel = DataPersistenceSystem.configurationModel.graphicsModel;

            // Dropdown
            display.value = _graphicsModel.displayOutput;
            resolution.value = _graphicsModel.resolution;
            windowMode.value = _graphicsModel.windowMode;
            textureQuality.value = _graphicsModel.textureQuality;

            // Toggle
            vSync.isOn = _graphicsModel.vSync;
        }
    }
}
