/*===============================================================
Product:    Samr Studio Core
Developer:  Eric Mitchell
Company:    Samr Studio
Date:       28/11/2021 22:37
================================================================*/
using UnityEngine;

namespace SamrStudio.Core
{
    public class SettingsSave
    {
        public float _masterVolume = default;
        public float _musicVolume = default;
        public float _sfxVolume = default;
        public int _resolutionsIndex = default;
        public int _antiAliasingIndex = default;
        public float _shadowDistance = default;
        public bool _isFullscreen = default;

        public void SaveSettings(SettingsSO settings)
        {
            _masterVolume = settings.MasterVolume;
            _musicVolume = settings.MusicVolume;
            _sfxVolume = settings.SfxVolume;
            _resolutionsIndex = settings.ResolutionsIndex;
            _antiAliasingIndex = settings.AntiAliasingIndex;
            _shadowDistance = settings.ShadowDistance;
            _isFullscreen = settings.IsFullscreen;
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public void LoadFromJson(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}