/*===============================================================
Product:    Samr Studio Core
Developer:  Eric Mitchell
Company:    Samr Studio
Date:       28/11/2021 22:12
================================================================*/
using UnityEngine;

namespace SamrStudio.Core
{
    [CreateAssetMenu(fileName = "Settings", menuName = "SamrStudio/ScriptableObjects/Settings")]
    public class SettingsSO : ScriptableObject
    {
        [SerializeField]
        private float masterVolume = default;
        [SerializeField]
        private float musicVolume = default;
        [SerializeField]
        private float sfxVolume = default;
        [SerializeField]
        private int resolutionsIndex = default;
        [SerializeField]
        private int antiAliasingIndex = default;
        [SerializeField]
        private float shadowDistance = default;
        [SerializeField]
        private bool isFullscreen = default;

        public float MasterVolume => masterVolume;
        public float MusicVolume => musicVolume;
        public float SfxVolume => sfxVolume;
        public int ResolutionsIndex => resolutionsIndex;
        public int AntiAliasingIndex => antiAliasingIndex;
        public float ShadowDistance => shadowDistance;
        public bool IsFullscreen => isFullscreen;

        public void SaveAudioSettings(float newMusicVolume, float newSfxVolume, float newMasterVolume)
        {
            masterVolume = newMasterVolume;
            musicVolume = newMusicVolume;
            sfxVolume = newSfxVolume;
        }

        public void SaveGraphicsSettings(int newResolutionsIndex, int newAntiAliasingIndex, float newShadowDistance, bool fullscreenState)
        {
            resolutionsIndex = newResolutionsIndex;
            antiAliasingIndex = newAntiAliasingIndex;
            shadowDistance = newShadowDistance;
            isFullscreen = fullscreenState;
        }

        public SettingsSO() { }

        public void LoadSavedSettings(SettingsSave savedFile)
        {
            masterVolume = savedFile._masterVolume;
            musicVolume = savedFile._musicVolume;
            sfxVolume = savedFile._sfxVolume;
            resolutionsIndex = savedFile._resolutionsIndex;
            antiAliasingIndex = savedFile._antiAliasingIndex;
            shadowDistance = savedFile._shadowDistance;
            isFullscreen = savedFile._isFullscreen;
        }
    }
}