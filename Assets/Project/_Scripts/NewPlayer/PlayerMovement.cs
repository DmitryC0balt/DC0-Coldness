using UnityEngine;

namespace Scripts.NewPlayer
{
    public class PlayerMovement
    {
        private Rigidbody _rigidbody;
        private float _movementSpeed;
        private Vector3 _currentDirection;

        public bool IsMoving {get; private set;}

        public PlayerMovement(Rigidbody rigidbody, PlayerMovementSetup playerMovementSetup)
        {
            _rigidbody = rigidbody;
            _movementSpeed = playerMovementSetup.movementSpeed;
        }


        public void SetDirection(Vector2 direction)
        {
            var newDirection = new Vector3(direction.x, 0, direction.y);
            _currentDirection = newDirection.normalized;
            
            IsMoving = CheckDirection();
        }


        public void PerformMovement()
        {
            _rigidbody.MovePosition(_rigidbody.position + _currentDirection * _movementSpeed * Time.fixedDeltaTime);
        }


        private bool CheckDirection() => _currentDirection.magnitude != 0;
    }
}