using UnityEngine;

namespace Scripts.Player
{
    public class PlayerRotation
    {
        private Rigidbody _rigidBody;
        private Camera _camera;
        private float _angularSpeed;


        public PlayerRotation(Rigidbody rigidbody, PlayerMovementSetup playerMovementSetup)
        {
            _camera = Camera.main;
            _rigidBody = rigidbody;
            _angularSpeed = playerMovementSetup.angularSpeed;
        }  


        public void PerformRotation()
        {
            
        }


        
    }
}