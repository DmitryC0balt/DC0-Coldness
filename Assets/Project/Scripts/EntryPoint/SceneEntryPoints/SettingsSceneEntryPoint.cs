using TMPro;
using UnityEngine.UI;

namespace Scripts.EntryPoint
{
    public sealed class SettingsSceneEntryPoint : SceneEntryPoint
    {
        public override void OnSceneEnter()
        {
            
        }


        public override void OnSceneExit()
        {
            
        }


        public void ExiSettingsScene()
        {
            _instance.HideSettingsScene();
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
