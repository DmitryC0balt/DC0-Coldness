using UnityEngine;

namespace Scripts.NewPlayer
{
    public class PlayerRotation
    {
        private Rigidbody _rigidbody;
        private float _angularSpeed;
        private Vector3 _currentDirection;


        public bool IsMoving{ get; private set;}


        public PlayerRotation(Rigidbody rigidbody, PlayerMovementSetup playerMovementSetup)
        {
            _rigidbody = rigidbody;
            _angularSpeed = playerMovementSetup.angularSpeed;
        }


        public void SetDirection(Vector2 direction)
        {
            IsMoving = false;

            var newDirection = new Vector3(direction.x, 0, direction.y);
            newDirection = newDirection.normalized;

            if (CheckDirection(_currentDirection, newDirection))
            {
                IsMoving = true;
            }

            _currentDirection = newDirection;
        }


        private bool CheckDirection(Vector3 oldDirection, Vector3 newDirection) => newDirection != oldDirection;


        public void PerformRotation()
        {
            if (_currentDirection.magnitude != 0)
            {
                Quaternion rotation = Quaternion.LookRotation(_currentDirection);
                _rigidbody.MoveRotation(Quaternion.Slerp(_rigidbody.rotation, rotation, _angularSpeed * Time.fixedDeltaTime));
            }
        }
    }
}