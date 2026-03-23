using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMovement
    {
        private Rigidbody _rigidbody;
        private float _movementSpeed;


        private Vector2 _currentDirection;


        public bool isMoving{ get; private set;}


        public PlayerMovement(Rigidbody rigidbody, PlayerMovementSetup playerMovementSetup)
        {
           _rigidbody = rigidbody;
           _movementSpeed = playerMovementSetup.movementSpeed;
        }


        public void SetDirection(Vector2 direction)
        {
            _currentDirection = direction;
        }


        public void PerformMovement()
        {
            var direction = new Vector3(_currentDirection.x, 0, _currentDirection.y).normalized;

            Vector3 newPosition = _rigidbody.position + direction * _movementSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(newPosition);
        }
    }


    [System.Serializable]
    public struct PlayerMovementSetup
    {
        public float movementSpeed;
        public float angularSpeed;
    }
}