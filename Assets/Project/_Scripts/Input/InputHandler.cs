using Scripts.EntryPoint;
using Scripts.MonoCash.Tier1;
using Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Input
{
    public class InputHandler : MonoCashListener
    {        
        [SerializeField] private PlayerHandler _playerHandler;

        private GameEntryPoint _instance;
        private Actions _actions;
        private InputSystem_Actions _inputSystemActions;

/*
        //Подписки
        private void OnEnable()
        {
            _instance = GameEntryPoint.GetInstance();


            _actions.Player.Pause.performed += SetPause;
            _actions.Player.Conversation.performed += SetConversation;
            _actions.Player.Inventory.performed += ShowInventory;
            _actions.Player.Records.performed += ShowRecords;
        }


        //Отписки
        private void OnDisable()
        {
            _actions.Player.Pause.performed -= SetPause;
            _actions.Player.Conversation.performed -= SetConversation;
            _actions.Player.Inventory.performed -= ShowInventory;
            _actions.Player.Records.performed -= ShowRecords;
        }
*/

        private void Start()
        {
            _instance = GameEntryPoint.GetInstance();
            _actions = new Actions();
            _inputSystemActions = new InputSystem_Actions();
        }


        //Обновление значений
        private void Update()
        {
            var movementDirection = _actions.Player.MovementDirection.ReadValue<Vector2>();
            Debug.Log(movementDirection);
        }


        //Пауза
        private void SetPause(InputAction.CallbackContext context)
        {
            
        }


        //Диалог
        private void SetConversation(InputAction.CallbackContext context)
        {
            
        }


        //Инвентарь
        private void ShowInventory(InputAction.CallbackContext context)
        {
            
        }


        //Записи
        private void ShowRecords(InputAction.CallbackContext context)
        {
            
        }


        //Произвести атаку
        private void PerformAttack(InputAction.CallbackContext context)
        {
            _playerHandler.PerformAttack();
        }


        //Задать позицию курсора
        private void SetMousePosition()
        {
            var mousePosition = _actions.Player.MousePosition.ReadValue<Vector2>();
        }


        //Задать направление движения            
        private void SetMovementDirection()
        {
            var movementDirection = _actions.Player.MovementDirection.ReadValue<Vector2>();
            Debug.Log(movementDirection);
            _playerHandler.SetMovementDirection(movementDirection);
        }

    }
}