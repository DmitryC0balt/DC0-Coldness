using Scripts.MonoCash.Tier1;
using UnityEngine;

namespace Scripts.NewPlayer
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerHandler : MonoCashListener
    {
        [SerializeField] private PlayerMovementSetup _playerMovementSetup;
        [SerializeField] private PlayerConversationSetup _playerConversationSetup;
        [SerializeField] private PlayerFieldOfVision _playerFieldOfVision;
        [SerializeField] private Rigidbody _rigidbody;
        
 

        private PlayerMovement _playerMovement;
        private PlayerRotation _playerRotation;
        private PlayerMouseRotation _playerMouseRotation;


        public override void OnInitialization()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _playerMovement = new PlayerMovement(_rigidbody, _playerMovementSetup);
            _playerRotation = new PlayerRotation(_rigidbody, _playerMovementSetup);
            _playerMouseRotation = new PlayerMouseRotation(_rigidbody, _playerMovementSetup);
        }


        public override void OnFixedProcess()
        {
            //Physics

            _playerMovement.PerformMovement();
            PlayerRotationLogic(_playerMovement.IsMoving);
        }


        public override void OnPostProcess()
        {
            //Visuals
        }


        public void SetMovementDirection(Vector2 direction)
        {
            _playerMovement.SetDirection(direction);
            _playerRotation.SetDirection(direction);
        }


        private void PlayerRotationLogic(bool isMoving)
        {
            if (isMoving)
            {
                _playerRotation.PerformRotation();
                return;
            }
            _playerMouseRotation.PerformRotation();
        }
    }


    [System.Serializable]
    public struct PlayerMovementSetup
    {
        [Header("Movement settings")]
        public float movementSpeed;

        [Header("Rotation settings")]
        public float angularSpeed;
        public float smoothness;
    }


    [System.Serializable]
    public struct PlayerConversationSetup
    {
        [Header("Gizmos")]
        [ColorUsage(true)] public Color gizmoColor;

        [Header("Availibility")]
        public float conversationRadius;
        public uint conversationCapacity;
    }
}