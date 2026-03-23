using UnityEngine;

namespace Scripts.NewPlayer
{
    public class PlayerMouseRotation
    {
        private Rigidbody _rigidbody;
        private Vector3 _currentMousePosition;
        private float _angularSpeed;


        public PlayerMouseRotation(Rigidbody rigidbody, PlayerMovementSetup playerMovementSetup)
        {
            _rigidbody = rigidbody;
            _angularSpeed = playerMovementSetup.angularSpeed;
        }


        public void SetDirection(Vector2 mousePosition)
        {
            
        }


        public void PerformRotation()
        {
           
        }
    
    }

}