using Scripts.EntryPoint;
using Scripts.MonoCash.Tier1;
using Scripts.NewPlayer;
using UnityEngine;

namespace Scripts.AltInput
{
    public class AltInputHandler : MonoCashListener
    {
        [SerializeField] private PlayerHandler _playerHandler;

        private GameEntryPoint _instance;
        private Camera _camera;

        private Vector2 _movementDirection;
        private Vector2 _mousePosition;


        private bool _isConversationOpen;
        private bool _isInventoryOpen;
        private bool _isRecordsOpen;


        
        public void SetCamera(Camera camera)
        {
            _camera = camera;
        }


        public override void OnInitialization()
        {
            _instance = GameEntryPoint.GetInstance();
        }


        public override void OnProcess()
        {
            GetMovementDirection();
            GetMousePosition();

            _playerHandler.SetMovementDirection(_movementDirection);
            //_playerHandler.SetMouseDirection(_mousePosition);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Пауза
            }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                //Диалог
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                //Инвентарь
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                //Записи
            }
        }


        private void GetMovementDirection()
        {
            var horizontalValue = Input.GetAxis("Horizontal");
            var verticalValue = Input.GetAxis("Vertical");
            _movementDirection = new Vector2(horizontalValue, verticalValue).normalized;
        }


        private void GetMousePosition()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                var targetPosition = hit.point;
                _mousePosition = targetPosition;
                Debug.Log(_mousePosition);
            }
        }


        private void PauseLogic()
        {
            
        }
    }
}