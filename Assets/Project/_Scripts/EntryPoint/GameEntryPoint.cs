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

        public void OpenMenuScene() => _sceneMaster.SwitchMenuState();
        
        public void OpenGameScene() => _sceneMaster.SwitchGameState();

        public void ShowSettingsScene() => _sceneMaster.OpenSettingsScene();

        public void HideSettingsScene() => _sceneMaster.CloseSettingsScene();

        public void ShowSettingsScene(bool isShow)
        {
            if (isShow)
            {
                _sceneMaster.OpenSettingsScene();
                return;
            }
            _sceneMaster.CloseSettingsScene();
        }


        //Сплэш-сцена
        public void ShowSplashScene(bool show)
        {
            
        }


        //Диалоговая сцена
        public void ShowDialogueScene(bool show)
        {
            
        }


        //Инвентарная сцена
        public void ShowInventoryScene(bool show)
        {
            
        }


        //Аргументарная сцена
        public void ShowRecordsScene(bool show)
        {
            
        }


        //Показать целевую сцену
        private void ShowTargetScene(bool show, string sceneName)
        {
            if (show)
            {
                
                return;
            }
        }

#endregion

    }
}