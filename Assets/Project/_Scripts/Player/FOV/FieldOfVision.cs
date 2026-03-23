using UnityEngine;


namespace Scripts.Player.FOV
{
    [RequireComponent(typeof(MeshFilter))]
    public class FieldOfVision : MonoBehaviour
    {
        [SerializeField] private PlayerFieldOfVisionSetup _fieldOfVisionSetup;
        [SerializeField] private float _angularSpeed;

        private MeshFilter _meshFilter;
        private Rigidbody _rigidbody;
        private Camera _camera;
        
        //private PlayerStats _playerStats;


        private Mesh _mesh;
        private Vector3 _origin;
        private float _fov = 100;
        private float _startAngle = 0;


        private const int _borderRayCount = 2;
        private const int _triangleVerticesCount = 3;
        private const int _startVertexIndex = 1;
        private const int _startTriangleIndex = 0;
        


        private void Start()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
            Initialization();
        }


        private void Update()
        {
            DrawSpreadField();
        }

        
        public void ShowFieldOfVision(bool isActive) => gameObject.SetActive(isActive);


        public void Initialization()
        {
            _mesh = new Mesh();
            _meshFilter = GetComponent<MeshFilter>();
            _meshFilter.mesh = _mesh;
        }



        //Метод отвечает за отрисовку
        public void DrawSpreadField()
        {
            float fov = _fieldOfVisionSetup.maxFovAngle;
            var rayCount = _fieldOfVisionSetup.rayCount;
            var distance = _fieldOfVisionSetup.maxDistance;

            var angle = _startAngle;
            var angleIncrease = fov / rayCount;

            Vector3[] vertices = new Vector3[rayCount + _borderRayCount];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[rayCount * _triangleVerticesCount];

            vertices[0] = _origin;

            var vertexIndex = _startVertexIndex;
            var triangleIndex = _startTriangleIndex;

            for (int i = 0; i <= rayCount; i++)
            {
                var direction = GetVectorFromAngle(angle);
                Vector3 vertex = _origin + direction * distance;


                if (!Physics.Raycast(_origin, direction, out var hit, _fieldOfVisionSetup.maxDistance, _fieldOfVisionSetup.objectLayer))
                {
                    vertex = _origin + GetVectorFromAngle(angle) * _fieldOfVisionSetup.maxDistance;
                }
                else
                {
                    vertex = hit.point;
                }

                vertices[vertexIndex] = vertex;

                if (i > 0)
                {
                    triangles[triangleIndex + 0] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += _triangleVerticesCount;
                }

                vertexIndex++;
            
                angle -= angleIncrease;
            }

            _mesh.vertices = vertices;
            _mesh.uv = uv;
            _mesh.triangles = triangles;
        }


        //Метод, возвращающий направленный (от угла) вектор
        private Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
        }


        private float GetAngleFromVector(Vector3 direction)
        {
            direction = direction.normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }


        public void SetOrigin()
        {
            _origin = transform.position;
        }


        public void PerformCursorRotation()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                Vector3 targetPosition = hit.point;

                Vector3 direction = targetPosition - _rigidbody.position;
                targetPosition.y = _rigidbody.position.y;

                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    _rigidbody.MoveRotation(Quaternion.Slerp(_rigidbody.rotation, targetRotation, _angularSpeed * Time.fixedDeltaTime));
                }
            }
        }
    }


    [System.Serializable]
    public struct PlayerFieldOfVisionSetup
    {
        [Header("Setup")]
        public int maxDistance;
        public float minFovAngle;
        public float maxFovAngle;
        [Header("Manual")]
        public int rayCount;
        [Header("Layers settigns")]
        public bool useEnemyLayer;
        public LayerMask enemyLayer;
        public bool useObjectLayer;
        public LayerMask objectLayer;
    }
}