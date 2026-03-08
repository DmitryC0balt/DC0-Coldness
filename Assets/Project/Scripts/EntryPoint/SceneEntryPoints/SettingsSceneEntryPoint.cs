using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.EntryPoint
{
    public sealed class SettingsSceneEntryPoint : SceneEntryPoint
    {
        [Header("Audio")]
        [SerializeField] private bool _isAudioSettingsActive;
        [SerializeField] private AudioSettingsStruct _audioSettingsStruct;
        [Space(10)]

        [Header("Graphics")]
        [SerializeField] private bool _isGraphicsSettingsActive;
        [SerializeField] private GraphicsSettingsStruct _graphicsSettingsStruct;
        [Space(10)]

        [Header("Language")]
        [SerializeField] private bool _isLanguageSettingsActive;
        [SerializeField] private LanguageSettingsStruct _languageSettingsStruct;
        [Space(10)]

        [Header("ExitSettings")]
        [SerializeField] private Button _exitButton;
        [Space(10)]

        [Header("ResetSettings")]
        [SerializeField] private bool _canResetSettings;
        [SerializeField] private Button _resetSettingsButton;
        [Space(10)]

        [Header("InputSettings")]
        [SerializeField] private bool _hasInputSettings;
        [SerializeField] private Button _switchButton;
        [SerializeField] private RectTransform _mainSettings;
        [SerializeField] private RectTransform _inputSettings;


        public override void OnSceneEnter()
        {
            throw new System.NotImplementedException();
        }


        public override void OnSceneExit()
        {
            throw new System.NotImplementedException();
        }


#region AUDIO SETTINGS REGION
        private void ShowAudioSettings(bool isActive)
        {
            _audioSettingsStruct.musicVolumeSlider?.gameObject.SetActive(isActive);
            _audioSettingsStruct.soundVolumeSlider?.gameObject.SetActive(isActive);
            _audioSettingsStruct.sfxVolumeSlider?.gameObject.SetActive(isActive);
        }


        private void SetupAudioSettings()
        {
            
        }


        private void GetVolume()
        {
            
        }


        private void SetVolume()
        {
            
        }

#endregion



#region GRAPHICS SETTINGS REGION

        private void ShowGraphicsSettings(bool isActive)
        {
            
        }


        private void GetQuality()
        {
            
        }


        private void SetQuality()
        {
            
        }


        private void GetResolution()
        {
            
        }


        private void SetResolution()
        {
            
        }

#endregion



#region LANGUAGE SETTINGS REGION

#endregion

        private void ResetSettings()
        {
            
        }


        private void SaveSettings()
        {
            
        }
      
    }


    [System.Serializable]
    public struct AudioSettingsStruct
    {
        public TMP_Text audioSettingsHeader;
        public Slider sfxVolumeSlider;
        public Slider soundVolumeSlider;
        public Slider musicVolumeSlider;
    }


    [System.Serializable]
    public struct GraphicsSettingsStruct
    {
        public TMP_Text graphicsSettingsHeader;
        public Dropdown qualityDropdown;
        public Dropdown resolutionDropdown;
        public Toggle windowedModeToggle;
    }


    [System.Serializable]
    public struct LanguageSettingsStruct
    {
        public TMP_Text languageHeader;
        public Dropdown languageDropdown;
    }
}
