using UnityEngine;

namespace Scripts.Player
{
    public class PlayerRotation
    {
        private CharacterController _characterController;
        private float _angularSpeed;
        private Vector2 _currentDirection;


        public void SetDirection(Vector2 direction) => _currentDirection = direction;

        public PlayerRotation(CharacterController characterController, PlayerMovementSetup playerMovementSetup)
        {
            _characterController = characterController;
            _angularSpeed = playerMovementSetup.angularSpeed;
        }


        public void PerformRotation()
        {
            if (Vector3.Angle(_characterController.transform.position, _currentDirection) > 0)
            {
                var newDirection = Vector3.RotateTowards(_characterController.transform.forward, _currentDirection, _angularSpeed, 0);
                _characterController.transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
        
    }
}