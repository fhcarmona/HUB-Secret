using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RMS
{
    public class AudioMenuController : MonoBehaviour
    {
        [Header("Slider List")]
        public Slider soundMasterSlider;
        public Slider soundEffectSlider;
        public Slider soundMusicSlider;

        [Header("Dropdown List")]
        public TMP_Dropdown audioOutputDevice;

        private AudioModel _audioModel;

        private FMOD.Studio.VCA masterVCA;
        private FMOD.Studio.VCA musicVCA;
        private FMOD.Studio.VCA effectVCA;
        private FMOD.System fSystem;

        public void Awake()
        {
            masterVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Master");
            musicVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
            effectVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Effect");

            fSystem = FMODUnity.RuntimeManager.CoreSystem;
        }

        public void Start()
        {
            PopulateAudioOutputDevice();
            SetConfigurationData();         
        }

        public void OnChangeMasterVolume(float sliderValue)
        {
            _audioModel.masterVolume = sliderValue;
        }
        public void OnChangeAudioVolume(float sliderValue)
        {
            _audioModel.effectVolume = sliderValue;
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
            {
                DataPersistenceSystem.configurationModel.audioModel = _audioModel;

                masterVCA.setVolume(DecibelToLinear(_audioModel.masterVolume));
                musicVCA.setVolume(DecibelToLinear(_audioModel.musicVolume));
                effectVCA.setVolume(DecibelToLinear(_audioModel.effectVolume));

                fSystem.setDriver(_audioModel.outputDevice);
            }
        }

        public void OnClickCancel()
        {
            SetConfigurationData();
        }

        public float DecibelToLinear(float dB)
        {
            return Mathf.Pow(10.0f, dB / 20f);
        }

        private void SetConfigurationData()
        {
            _audioModel = DataPersistenceSystem.configurationModel.audioModel;

            // Slider
            soundMasterSlider.value = _audioModel.masterVolume;
            soundEffectSlider.value = _audioModel.effectVolume;
            soundMusicSlider.value = _audioModel.musicVolume;

            // Dropdown
            audioOutputDevice.value = _audioModel.outputDevice;
        }

        private void PopulateAudioOutputDevice()
        {
            List<string> outputList = new List<string>();

            fSystem.getNumDrivers(out int devices);

            for (int index = 0; index<devices; index++)
            {
                fSystem.getDriverInfo(index, out string name, 128, out System.Guid guid, out int systemrate, out FMOD.SPEAKERMODE speakermode, out int speakermodechannels);

                outputList.Add(name);
            }

            audioOutputDevice.ClearOptions();
            audioOutputDevice.AddOptions(outputList);
        }
    }
}