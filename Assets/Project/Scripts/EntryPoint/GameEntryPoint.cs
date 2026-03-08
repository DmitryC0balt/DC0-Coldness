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

        private GameEntryPoint()
        {
            LoadGameMaster();
    
            _sceneMaster = new SceneMaster();
            _dataMaster = new DataMaster();
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

        public void OpenMenuScene() => _sceneMaster.SwitchMenuState();

        public void OpenGameScene() => _sceneMaster.SwitchGameState();

        public void ShowMenuScene() => _sceneMaster.OpenSettingsScene();

        public void HideMenuScene() => _sceneMaster.CloseSettingsScene();

#endregion





    }
}