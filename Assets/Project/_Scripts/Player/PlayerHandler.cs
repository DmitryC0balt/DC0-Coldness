using Scripts.Health;
using Scripts.MonoCash.Tier1;
using Scripts.Player.FOV;
using UnityEngine;


namespace Scripts.Player
{
    public class PlayerHandler : MonoCashListener
    {
        //Вводные данные
        [Header("Components")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;


        [Header("Setups")]
        [SerializeField] private PlayerMovementSetup _playerMovementSetup;
        [SerializeField] private PlayerAttackSetup _playerAttackSetup;
        [SerializeField] private PlayerConversationSetup _playerConversationSetup;
        [SerializeField] private PlayerFieldOfVisionSetup _playerFieldOfVisionSetup;
        [SerializeField] private FieldOfVision _fieldOfVision;

        //Классы
        //private PlayerStats _playerStats;
        private PlayerMovement _playerMovement;
        private PlayerRotation _playerRotation;
        
        private PlayerAttack _playerAttack;
        private HealthMaster _playerHealth;    

        private Camera _camera;
    

        //Данные для прочтения/изменения
        private bool isMoving => _playerMovement.isMoving;


        private void OnEnable()
        {
            
            
        }


        private void Start() => OnInitialization();


        private void FixedUpdate() => OnFixedProcess();

        private void LateUpdate() => OnFixedProcess();


        public override void OnInitialization()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();

            _playerMovement = new PlayerMovement(_rigidbody, _playerMovementSetup);
            _playerRotation = new PlayerRotation(_rigidbody, _playerMovementSetup);


            _playerAttack = new PlayerAttack();
            _camera = Camera.main;

            _fieldOfVision.Initialization();
           
            _fieldOfVision.DrawSpreadField();
        }


        public void SetDirection(Vector2 direction)
        {
            _playerMovement.SetDirection(direction);
            //_fieldOfVision.SetOrigin(transform.position);
        }


        public void PerformAttack()
        {
            
        }


#region UPDATE_REGION

        public override void OnFixedProcess()
        {
            _playerMovement.PerformMovement();
           //_fieldOfVision.PerformCursorRotation();
        }


        public override void OnPostProcess()
        {
            
        }

#endregion



#region GIZMO_REGION

        private void OnDrawGizmos()
        {
            if (_playerConversationSetup.drawGizmo)
            {
                Gizmos.color = _playerConversationSetup.gizmoColor;
                Gizmos.DrawWireSphere(gameObject.transform.position, _playerConversationSetup.conversationRadius);
            }
        }

#endregion

        //P.S. Изначальный код был чудовищный, пришлось около 2 часов портатить, чтобы переписать его
        //с эльфийского на структурный!!!
    }


    [System.Serializable]
    public struct PlayerConversationSetup
    {
        public float conversationRadius;
        public bool drawGizmo;
        [ColorUsage(true)]public Color gizmoColor;
    }
}