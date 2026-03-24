using Scripts.AltInput;
using Scripts.CameraMovement;
using Scripts.MonoCash.Tier1;
using Scripts.NewPlayer;
using UnityEngine;


namespace Scripts.EntryPoint
{
    public sealed class GameSceneEntryPoint : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Camera _camera;

        [Header("Handlers")]
        [SerializeField] private CameraHandler _cameraHandler; 
        [SerializeField] private PlayerHandler _playerHandler;
        [SerializeField] private AltInputHandler _inputHandler;
        //[SerializeField] private InputHandler _inputHandler;
                
        private MonoCashObserver _monoCashObserver;



        private void Start()
        {
            _inputHandler.SetCamera(_camera);
            _cameraHandler.SetCamera(_camera);

            _cameraHandler.OnInitialization();
            _playerHandler.OnInitialization();
            _inputHandler.OnInitialization();
        }


        private void Update()
        {
            _inputHandler.OnProcess();
            _playerHandler.OnProcess();
        }


        private void FixedUpdate()
        {
            _playerHandler.OnFixedProcess();
            _cameraHandler.OnFixedProcess();
        }


        private void LateUpdate()
        {
            _playerHandler.OnPostProcess();
        }

    }
}