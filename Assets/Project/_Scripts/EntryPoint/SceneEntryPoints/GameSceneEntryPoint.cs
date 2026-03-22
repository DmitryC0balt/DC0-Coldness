using Scripts.CameraMovement;
using Scripts.MonoCash.Tier1;
using Scripts.Player;
using UnityEngine;


namespace Scripts.EntryPoint
{
    public sealed class GameSceneEntryPoint : SceneEntryPoint
    {
        [Header("Handlers")]
        [SerializeField] private CameraHandler _cameraHandler; 
        [SerializeField] private PlayerHandler _playerHandler;
                
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
            _monoCashObserver.OnProcess();
        }


        protected override void OnFixedProcess()
        {
            _monoCashObserver.OnFixedProcess();
        }


        protected override void OnPostProcess()
        {
            _monoCashObserver.OnPostProcess();
        }


        private void OpenMenuScene() => _instance.OpenMenuScene();

    }

}