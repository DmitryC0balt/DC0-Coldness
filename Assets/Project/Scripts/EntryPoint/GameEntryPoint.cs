using Scripts.Master;
using UnityEngine;

namespace Scripts.EntryPoint
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;

        private GameMaster _gameMaster;
        private SceneMaster _sceneMaster;
        private DataMaster _dataMaster;

        
        public bool isSplashScreenShowed{get; private set;}

        private GameEntryPoint()
        {
            LoadGameMaster();
    
            _sceneMaster = new SceneMaster(_gameMaster);
            _dataMaster = new DataMaster(_gameMaster.GetDataStruct());
            
            isSplashScreenShowed = false;
        }


        public static GameEntryPoint GetInstance()
        {
            _instance ??= new GameEntryPoint();
            return _instance;
        }


        private void LoadGameMaster()
        {
            var gameMaster = Resources.Load<GameMaster>("Prefabs/GameMaster");
            _gameMaster = Object.Instantiate(gameMaster);
            Object.DontDestroyOnLoad(_gameMaster.gameObject);
        }


#region SCENE_MASTER

        public void OpenMenuScene()
        {
            _sceneMaster.SwitchMenuState();

            if (!isSplashScreenShowed)
            {
                ShowSplashScene();
                isSplashScreenShowed = true;
            }
        }

        public void OpenGameScene() => _sceneMaster.SwitchGameState();

        public void ShowSettingsScene() => _sceneMaster.OpenSettingsScene();

        public void HideSettingsScene() => _sceneMaster.CloseSettingsScene();

        public void ShowSplashScene() => _sceneMaster.OpenSplashScene();

        public void HideSplashScene() => _sceneMaster.CloseSplashScene();

#endregion

    }
}