using Scripts.MonoCash.Tier1;
using UnityEngine;

namespace Scripts.NewPlayer
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerHandler : MonoCashListener
    {
        [SerializeField] private PlayerMovementSetup _playerMovementSetup;
        [SerializeField] private PlayerConversationSetup _playerConversationSetup;
        [SerializeField] private PlayerAttackSetup _playerAttackSetup;
        [SerializeField] private PlayerFieldOfVision _playerFieldOfVision;
        [SerializeField] private Rigidbody _rigidbody;
    

        private PlayerMovement _playerMovement;
        private PlayerRotation _playerRotation;
        private PlayerMouseRotation _playerMouseRotation;
        private PlayerConversation _playerConversation;
        private PlayerAttack _playerAttack;


        public override void OnInitialization()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _playerMovement = new PlayerMovement(_rigidbody, _playerMovementSetup);
            _playerRotation = new PlayerRotation(_rigidbody, _playerMovementSetup);
            _playerMouseRotation = new PlayerMouseRotation(_rigidbody, _playerMovementSetup);

            _playerFieldOfVision.OnInitialization();
        }


        public override void OnProcess()
        {
            _playerFieldOfVision.SetOrigin(transform.position);
            _playerFieldOfVision.UpdateSpread(CheckMovRot());
        }


        public override void OnFixedProcess()
        {
            //Physics
            _playerMovement.PerformMovement();
            PlayerRotationLogic(_playerMovement.IsMoving);
            Debug.Log(transform.position);
        }


        public override void OnPostProcess()
        {
            //Visuals
            _playerFieldOfVision.OnPostProcess();
        }


        private bool CheckMovRot() => _playerMovement.IsMoving || _playerRotation.IsMoving;

        private bool CheckMovement() => _playerMovement.IsMoving;

        public void SetMovementDirection(Vector2 direction)
        {
            _playerMovement.SetDirection(direction);
            _playerRotation.SetDirection(direction);
        }


        public void SetMousePosition(Vector3 mousePosition)
        {
            var direction = mousePosition - _rigidbody.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                direction = direction.normalized;
                _playerMouseRotation.SetMousePosition(direction);
                _playerFieldOfVision.SetDirection(direction);
                Debug.Log(direction);
            }

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


        public void PerformAttack()
        {
            if (CheckMovement())
            {
                Debug.Log("Can't perform shoot while player moved!");
                return;
            }

            _playerAttack.PerformAttack();
        }


        private void OnDrawGizmos()
        {
            if (_playerConversationSetup.drawGizmo)
            {
                Gizmos.color = _playerConversationSetup.gizmoColor;
                var radius = _playerConversationSetup.conversationRadius;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
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
        public bool drawGizmo;
        [ColorUsage(true)] public Color gizmoColor;

        [Header("Availibility")]
        public float conversationRadius;
        public uint conversationCapacity;
    }


    [System.Serializable]
    public struct PlayerAttackSetup
    {
        public int atkValue;
        public Transform firePoint;
        public GameObject muzzleFlash;
        public GameObject objectImpact;
        public GameObject bloodImpact;
    }
}