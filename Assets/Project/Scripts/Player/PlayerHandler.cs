using Scripts.MonoCash.Tier1;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerHandler : MonoCashListener
    {
        //Вводные данные
        [Header("Components")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        [SerializeField] private Image _fovImage;


        [Header("Setups")]
        [SerializeField] private PlayerMovementSetup _playerMovementSetup;


        //Классы
        //private PlayerStats _playerStats;
        private PlayerMovement _playerMovement;
        private PlayerRotation _playerRotation;
        
        private PlayerAttack _playerAttack;    
    

        //Данные для прочтения/изменения
        private bool isMoving => _playerMovement.isMoving;


        private void OnEnable()
        {
            
            
        }


        public override void OnInitialization()
        {
            _characterController = GetComponent<CharacterController>();
            _playerMovement = new PlayerMovement(_characterController, _playerMovementSetup);
            _playerRotation = new PlayerRotation(_characterController, _playerMovementSetup);

            _playerAttack = new PlayerAttack();
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