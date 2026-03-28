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
        private Vector3 _mousePosition;


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
            ButtonLogic();

            GetMovementDirection();
            GetMousePosition();

            _playerHandler.SetMovementDirection(_movementDirection);
            _playerHandler.SetMousePosition(_mousePosition);
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
                Vector3 targetPosition = hit.point;
                _mousePosition = targetPosition;
            }
        }


        private void ButtonLogic()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
            }


            if (Input.GetKeyDown(KeyCode.Q))
            {
              
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                
            }
        }
    }
}