using UnityEngine;

namespace Scripts.NewPlayer
{
    public class PlayerMouseRotation
    {
        private Rigidbody _rigidbody;
        private Vector3 _currentDirection;
        private float _angularSpeed;


        public PlayerMouseRotation(Rigidbody rigidbody, PlayerMovementSetup playerMovementSetup)
        {
            _rigidbody = rigidbody;
            _angularSpeed = playerMovementSetup.angularSpeed;
        }


        public void SetMousePosition(Vector3 mousePosition)
        {
            var currentMousePosition = new Vector3(mousePosition.x, 0, mousePosition.z);
            _currentDirection = currentMousePosition;
        }


        public void PerformRotation()
        {
            Quaternion targetRotation = Quaternion.LookRotation(_currentDirection);
            _rigidbody.MoveRotation(Quaternion.Slerp(_rigidbody.rotation, targetRotation, _angularSpeed * Time.fixedDeltaTime));   
        }
    
    }

}