using Scripts.CameraMovement;
using Scripts.Conversation;
using Scripts.Effect;
using Scripts.GUI;
using Scripts.Inventory;
using Scripts.MonoCash.Tier1;
using Scripts.Pause;
using Scripts.Player;
using UnityEngine;

namespace Scripts.EntryPoint
{
    public sealed class GameSceneEntryPoint : SceneEntryPoint
    {
        [Header("Handlers")]
        [SerializeField] private CameraHandler _cameraHandler; 
        [SerializeField] private PlayerHandler _playerHandler;
        [SerializeField] private ConversationHandler _conversationHandler;
        [SerializeField] private InventoryHandler _inventoryHandler;
        [SerializeField] private PauseHandler _pauseHandler;
        [SerializeField] private ScreenEffectHandler _screenEffectHandler;


        [Header("Screens")]
        [SerializeField] private PauseScreen _pauseScreen;
        [SerializeField] private InventoryScreen _inventoryScreen;
        [SerializeField] private ConversationScreen _conversationScreen;
        

        private MonoCashObserver _monoCashObserver;



        public override void OnSceneEnter()
        {
            _monoCashObserver = new MonoCashObserver();
        }


        public override void OnSceneExit()
        {
            
        }


        protected override void OnInitialization()
        {
            _monoCashObserver.OnInitialization();
        }


        protected override void OnProcess()
        {
            if (!_pauseHandler.isPaused)
            {
                _monoCashObserver.OnProcess();
            }
        }


        protected override void OnFixedProcess()
        {
            if (!_pauseHandler.isPaused)
            {
                _monoCashObserver.OnFixedProcess();
            }
        }


        protected override void OnPostProcess()
        {
            if (!_pauseHandler.isPaused)
            {
                _monoCashObserver.OnPostProcess();
            }
        }


        public void ShowConversationScreen(bool isActive)
        {
            
        }


        public void ShowInventoryScreen(bool isActive)
        {
            
        }


        public void SetPause(bool isActive) => _pauseHandler.SetPause(isActive);

        public void ShowSettings() => _instance.ShowSettingsScene();

        public void OpenMenuScene() => _instance.OpenMenuScene();
    }

}