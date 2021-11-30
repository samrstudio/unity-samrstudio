/*===============================================================
Product:    Samr Studio Core
Developer:  Eric Mitchell
Company:    Samr Studio
Date:       28/11/2021 21:52
================================================================*/
using SamrStudio.Core.Events;
using SamrStudio.Core.Utilities;
using UnityEngine;
//using UnityEngine.Rendering.Universal;

namespace SamrStudio.Core
{
    public class SettingsSystem : MonoBehaviour
    {
        [SerializeField] private VoidEventSO SaveSettingsEvent = default;

        [SerializeField]
        private SettingsSO currentSettings = default;
        //[SerializeField]
        //private UniversalRenderPipelineAsset urpAsset = default;
        //[SerializeField]
        //private SaveSystem saveSystem = default;

        [SerializeField] private FloatEventSO _changeMasterVolumeEventChannel = default;
        [SerializeField] private FloatEventSO _changeSFXVolumeEventChannel = default;
        [SerializeField] private FloatEventSO _changeMusicVolumeEventChannel = default;

        private void Awake()
        {
            //saveSystem.LoadSaveDataFromDisk();
            //currentSettings.LoadSavedSettings(saveSystem.saveData);
            SetCurrentSettings();
        }

        private void OnEnable()
        {
            SaveSettingsEvent.OnEventRaised += SaveSettings;
        }

        private void OnDisable()
        {
            SaveSettingsEvent.OnEventRaised -= SaveSettings;
        }

        /// <summary>
        /// Set current settings 
        /// </summary>
        void SetCurrentSettings()
        {
            _changeMusicVolumeEventChannel.RaiseEvent(currentSettings.MusicVolume);//raise event for volume change
            _changeSFXVolumeEventChannel.RaiseEvent(currentSettings.SfxVolume); //raise event for volume change
            _changeMasterVolumeEventChannel.RaiseEvent(currentSettings.MasterVolume); //raise event for volume change
            Resolution currentResolution = Screen.currentResolution; // get a default resolution in case saved resolution doesn't exist in the resolution List
            if (currentSettings.ResolutionsIndex < Screen.resolutions.Length)
                currentResolution = Screen.resolutions[currentSettings.ResolutionsIndex];
            Screen.SetResolution(currentResolution.width, currentResolution.height, currentSettings.IsFullscreen);
            //urpAsset.shadowDistance = currentSettings.ShadowDistance;
            //urpAsset.msaaSampleCount = currentSettings.AntiAliasingIndex;
        }

        void SaveSettings(Void ignore)
        {
            Debug.Log("Save Settings");
            //saveSystem.SaveDataToDisk();
        }
    }
}