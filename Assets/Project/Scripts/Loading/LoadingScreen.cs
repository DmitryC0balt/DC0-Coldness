using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Loading
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private LoadingBarStruct _loadingBarStruct;
        [SerializeField] private BackgroundStruct _backgroundStruct;
        [SerializeField] private ReadyLabelStruct _readyLabelStruct;


        private void ShowLoadingBar(bool isActive = true)
        {
            
        }


        private void ShowReadyLabel(bool isActive = true)
        {
            
        }


        private void UpdateLoadingBar()
        {
            
        }


        

    }


    [System.Serializable]
    public struct LoadingBarStruct
    {
        public Image _loadingBar;
        public Image _loadingBarFill;
    } 


    [System.Serializable]
    public struct BackgroundStruct
    {
        public Image _background;
        public bool _isRandomBackground;
        public Sprite _mainImage;
        public Sprite[] _backgroundImages;
    }


    [System.Serializable]
    public struct ReadyLabelStruct
    {
        public TMP_Text _label;
        public Button _button;
    }

}