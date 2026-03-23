using UnityEngine;

namespace Scripts.NewPlayer
{
    public class PlayerRotation
    {
        private Rigidbody _rigidbody;
        private float _angularSpeed;
        private float _smoothness;
        private Vector3 _currentDirection;


        public PlayerRotation(Rigidbody rigidbody, PlayerMovementSetup playerMovementSetup)
        {
            _rigidbody = rigidbody;
            _angularSpeed = playerMovementSetup.angularSpeed;
            _smoothness = playerMovementSetup.smoothness;
        }


        public void SetDirection(Vector2 direction)
        {
            var newDirection = new Vector3(direction.x, 0, direction.y);
            _currentDirection = newDirection.normalized;
        }


        public void PerformRotation()
        {
            if (_currentDirection.magnitude != 0)
            {
                Quaternion rotation = Quaternion.LookRotation(_currentDirection);
                _rigidbody.MoveRotation(Quaternion.Slerp(_rigidbody.rotation, rotation, _smoothness * Time.fixedDeltaTime));
            }
        }
    }
}