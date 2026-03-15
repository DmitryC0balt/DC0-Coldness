using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMovement
    {
        private CharacterController _characterController;
        private float _movementSpeed;


        private Vector2 _currentDirection;


        public bool isMoving{ get; private set;}


        public PlayerMovement(CharacterController characterController, PlayerMovementSetup playerMovementSetup)
        {
            _characterController = characterController;
            _movementSpeed = playerMovementSetup.movementSpeed;
        }


        public void SetDirection(Vector2 direction)
        {
            _currentDirection = direction;

            if (_currentDirection.magnitude > 0)
            {
                isMoving = true;
                return;
            }

            isMoving = false;
        }


        public void PerformMovement()
        {
            var direction = new Vector3(_currentDirection.x, 0, _currentDirection.y);
            _characterController.Move(direction * _movementSpeed * Time.deltaTime);
        }
    }


    [System.Serializable]
    public struct PlayerMovementSetup
    {
        public float movementSpeed;
        public float angularSpeed;
    }
}