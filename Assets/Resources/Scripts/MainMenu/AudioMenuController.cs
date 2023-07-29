using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RMS
{
    public class Audio : MonoBehaviour
    {
        [Header("Slider List")]
        public Slider soundEffectVolume;
        public Slider musicVolume;

        [Header("Dropdown List")]
        public TMP_Dropdown audioOutputDevice;

        private AudioModel _audioModel;

        public void Start()
        {
            SetConfigurationData();
        }

        public void OnChangeAudioVolume(float sliderValue)
        {
            _audioModel.audioVolume = sliderValue;
        }
        public void OnChangeMusicVolume(float sliderValue)
        {
            _audioModel.musicVolume = sliderValue;
        }
        public void OnChangeAudioOutput(int dropdownValue)
        {
            _audioModel.outputDevice = dropdownValue;
        }

        public void OnClickSave()
        {
            if (_audioModel != null)
                DataPersistenceSystem.configurationModel.audioModel = _audioModel;
        }

        public void OnClickCancel()
        {
            SetConfigurationData();
        }

        private void SetConfigurationData()
        {
            _audioModel = DataPersistenceSystem.configurationModel.audioModel;

            // Slider
            soundEffectVolume.value = _audioModel.audioVolume;
            musicVolume.value = _audioModel.musicVolume;

            // Dropdown
            audioOutputDevice.value = _audioModel.outputDevice;
        }
    }
}