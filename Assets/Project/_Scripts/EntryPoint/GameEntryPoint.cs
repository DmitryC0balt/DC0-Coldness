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

        //Меню
        public void OpenMenuScene() => _sceneMaster.SwitchMenuState();
        
        //Игра
        public void OpenGameScene() => _sceneMaster.SwitchGameState();

        //Пауза
        public void ShowPause(bool isActive) => _sceneMaster.OpenTargetScene(isActive, "Pause");

        //Настройки
        public void ShowSettings(bool isActive) => _sceneMaster.OpenTargetScene(isActive, "Settings");

        //Заставка
        public void ShowSplash(bool isActive) => _sceneMaster.OpenTargetScene(isActive, "Splash");

        //Диалог
        public void ShowConversation(bool isActive) => _sceneMaster.OpenTargetScene(isActive, "Conversation");

        //Инвентарь
        public void ShowInventory(bool isActive) => _sceneMaster.OpenTargetScene(isActive, "Inventory");

        //Записи
        public void ShowRecords(bool isActive) => _sceneMaster.OpenTargetScene(isActive, "Records");

        //Конец игры
        public void ShowGameOver(bool isActive) => _sceneMaster.OpenTargetScene(isActive, "GameOver");

#endregion



#region DATA_MASTER

        //Игра приостановлена
        public bool isGamePaused => _dataMaster.isGamePaused;

        //Открыты сторонние сцены
        public bool hasSideScenes => _dataMaster.hasSideScenes;
#endregion

    }
}