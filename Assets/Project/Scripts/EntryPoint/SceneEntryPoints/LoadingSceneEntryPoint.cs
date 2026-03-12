using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.EntryPoint
{
    public class LoadingSceneEntryPoint : SceneEntryPoint
    {
        [Header("Background setup")]
        [SerializeField] private BackgroundSetupStruct _backgroundSetupStruct;

        [Header("Loading bar setup")]
        [SerializeField] private LoadingBarSetupStruct _loadingBarSetupStruct;

        [Header("Ready label setup")]
        [SerializeField] private ReadyLabelSetupStruct _readyLabelSetupStruct;

        [Header("Other elements setup")]
        [SerializeField] private OtherElementsSetupStruct _otherElementsSetupStruct;
        
        public bool isReadyButtonPressed{ get; private set;}



        public override void OnSceneEnter()
        {
            
        }


        public override void OnSceneExit()
        {
            
        }


        public void SetLoadingBarValue(float value) => _loadingBarSetupStruct.loadingBarFill.fillAmount = value;

        public void ShowLoadingBar(bool isActive = true) => _loadingBarSetupStruct.loadingBarImage.gameObject.SetActive(isActive);

        private void OnPressReadyButton() => isReadyButtonPressed = true;

        public void ShowReadyAccept()
        {
            
        }


        

    }


    [System.Serializable]
    public struct BackgroundSetupStruct
    {
        public Image _background;
        public Sprite _mainImage;
        public bool _randomBackground;
        public Sprite[] _randomBackgroundImages;
    }


    [System.Serializable]
    public struct LoadingBarSetupStruct
    {
        public Image loadingBarImage;
        public Image loadingBarFill;
    }


    [System.Serializable]
    public struct ReadyLabelSetupStruct
    {
        public TMP_Text _readyLabel;
        public bool _buttonOnScreen;
        public Button _readyButton;
    }


    [System.Serializable]
    public struct OtherElementsSetupStruct
    {
        public bool _useHint;
        public Image _hintBackground;
        public TMP_Text _hintHeader;
        public TMP_Text _hintText;
    }
}