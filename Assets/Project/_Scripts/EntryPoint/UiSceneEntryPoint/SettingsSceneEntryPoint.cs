using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.EntryPoint
{
    public sealed class SettingsSceneEntryPoint : SceneEntryPoint
    {
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider; 


        public override void OnSceneEnter()
        {
            SetSliderValue(_soundSlider);
            SetSliderValue(_musicSlider);
            SetSliderValue(_sfxSlider);
        }


        public override void OnSceneExit()
        {
            
        }


        private void SetSliderValue(Slider slider)
        {
            
        }


        public void ResetSettings()
        {
            
        }


        public void ExiSettingsScene()
        {
            _instance.ShowSettings(false);
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
