using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RMS
{
    public class Graphics : MonoBehaviour
    {
        [Header("Dropdown List")]
        public TMP_Dropdown resolution;
        public TMP_Dropdown textureQuality;
        public TMP_Dropdown windowMode;

        [Header("Toggle List")]
        public Toggle vSync;

        [Header("Pipeline List")]
        public RenderPipelineAsset[] renderPipeline;

        private GraphicsModel _graphicsModel;

        private const string resolutionSplitChar = "x";

        public void Awake()
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
            {
                DataPersistenceSystem.configurationModel.graphicsModel = _graphicsModel;
                QualitySettings.vSyncCount = Convert.ToInt32(vSync.isOn);
                QualitySettings.SetQualityLevel(textureQuality.value);
                QualitySettings.renderPipeline = renderPipeline[textureQuality.value];
                SetResolutionByString(resolution.options[_graphicsModel.resolution].text);
            }
        }

        public void OnClickCancel()
        {
            SetConfigurationData();
        }

        private void SetConfigurationData()
        {
            _graphicsModel = DataPersistenceSystem.configurationModel.graphicsModel;

            // Dropdown
            resolution.value = _graphicsModel.resolution;
            windowMode.value = _graphicsModel.windowMode;
            textureQuality.value = _graphicsModel.textureQuality;

            // Toggle
            vSync.isOn = _graphicsModel.vSync;
        }

        private void SetResolutionByString(string resolution)
        {
            string[] splitValues;

            splitValues = resolution.Split(resolutionSplitChar);

            Screen.SetResolution(int.Parse(splitValues[0]), int.Parse(splitValues[1]), (FullScreenMode)_graphicsModel.windowMode);
        }
    }
}
