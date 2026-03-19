using Scripts.GUI;
using UnityEngine;

namespace Scripts.Pause
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private bool _isPause;
        [SerializeField] private PauseScreen _pauseScreen;
        

        private const int defaultTimeScale = 1;
        private const int pausedTimeScale = 0;

        public bool isPaused{ get; private set;}


        public void SetPause(bool isActive)
        {
            SetTimeScale(isActive);
            ShowPauseScreen(isActive);
            _isPause = isActive;
        }


        private void SetTimeScale(bool isPauseActive)
        {
            if (isPauseActive)
            {
                Time.timeScale = pausedTimeScale;
                return;
            }
            
            Time.timeScale = defaultTimeScale;
        }


        private void ShowPauseScreen(bool isPauseActive)
        {
            if (isPauseActive)
            {
                _pauseScreen.Show();
                return;
            }

            _pauseScreen.Hide();
        }
    }
}