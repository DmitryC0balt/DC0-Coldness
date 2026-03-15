using Scripts.GUI;
using UnityEngine;

namespace Scripts.EntryPoint
{
    public sealed class MenuSceneEntryPoint : SceneEntryPoint
    {
        //Значится, так - здесь все, что касается сцены с основным меню - и только с ним.
        //Все, что не относится к меню - долой. Настройки тоже, они в другой сцене.

        [SerializeField] private CreditsScreen _creditsScreen;
        [SerializeField] private MainMenuScreen _mainMenuScreen;
        [SerializeField] private ExitConfirmScreen _exitConfirmScreen;


        public override void OnSceneEnter() => ShowMenuScreen();

        public override void OnSceneExit() {}


        public void HideAllScreens()
        {
            _mainMenuScreen.Hide();
            _creditsScreen.Hide();
            _exitConfirmScreen.Hide();
        }


        public void ShowMenuScreen()
        {
            HideAllScreens();
            _mainMenuScreen.Show();
        }


        public void ShowCreditsScreen()
        {
            HideAllScreens();
            _creditsScreen.Show();
        }


        public void ShowSettingsScene() => _instance.ShowSettingsScene();

        public void EnterGameScene() => _instance.OpenGameScene();


        public void ShowExitConfirmScreen(bool isActive)
        {
            if (isActive)
            {
                _exitConfirmScreen.Show();
                return;
            }

            _exitConfirmScreen.Hide();
        }


        public void ExitGame() => Application.Quit();

    }

}