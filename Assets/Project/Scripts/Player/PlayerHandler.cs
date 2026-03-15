using Scripts.MonoCash.Tier1;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerHandler : MonoCashListener
    {
        //Вводные данные
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerMovementSetup _playerMovementSetup;


        //Классы
        private PlayerMovement _playerMovement;
        private PlayerRotation _playerRotation;


        //Данные для прочтения/изменения
        public bool isMoving => _playerMovement.isMoving;


        public override void OnInitialization()
        {
            _characterController = GetComponent<CharacterController>();
            _playerMovement = new PlayerMovement(_characterController, _playerMovementSetup);
            _playerRotation = new PlayerRotation(_characterController, _playerMovementSetup);
        }


        public void SetDirectionVector(InputAction.CallbackContext context)
        {
            var movementInputVector = context.ReadValue<Vector2>();
            _playerMovement.SetDirection(movementInputVector);

            if (isMoving)
            {
                _playerRotation.SetDirection(movementInputVector);
                return;
            }
        }


        public override void OnFixedProcess()
        {
            //Здесь вся физика!!!
            _playerMovement.PerformMovement();//Здесь ходить
            _playerRotation.PerformRotation();//Здесь крутиться
            //Атака в пути
        }


        public override void OnPostProcess()
        {
            //Здесь вся визуальщина!!!
        }


        //P.S. Изначальный код был чудовищный, пришлось около 2 часов портатить, чтобы переписать его
        //с эльфийского на структурный!!!
    }
}