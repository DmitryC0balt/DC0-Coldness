using UnityEngine;


namespace Scripts.Player.FOV
{
    [RequireComponent(typeof(MeshFilter))]
    public class FieldOfVision : MonoBehaviour
    {
        [SerializeField] private PlayerFieldOfVisionSetup _fieldOfVisionSetup;


        private MeshFilter _meshFilter;
        //private PlayerStats _playerStats;


        private Mesh _mesh;
        private const int _borderRayCount = 2;
        private const int _triangleVerticesCount = 3;
        private const int _startVertexIndex = 1;
        private const int _startTriangleIndex = 0;
        private const float _startAngle = 0;


        private void Start()
        {
            Initialization();
        }


        private void LateUpdate()
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
            
            Vector3 origin = Vector3.zero;

            float fov = _fieldOfVisionSetup.maxFovAngle;
            var rayCount = _fieldOfVisionSetup.rayCount;
            var distance = _fieldOfVisionSetup.maxDistance;

            var angle = _startAngle;
            var angleIncrease = fov / rayCount;

            Vector3[] vertices = new Vector3[rayCount + _borderRayCount];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[rayCount * _triangleVerticesCount];

            vertices[0] = origin;

            var vertexIndex = _startVertexIndex;
            var triangleIndex = _startTriangleIndex;

            for (int i = 0; i <= rayCount; i++)
            {
                var direction = GetVectorFromAngle(angle);
                Vector3 vertex = origin + direction * distance;


                if (!Physics.Raycast(origin, direction, out var hit, _fieldOfVisionSetup.maxDistance, _fieldOfVisionSetup.objectLayer))
                {
                    vertex = origin + GetVectorFromAngle(angle) * _fieldOfVisionSetup.maxDistance;
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


        //Метод отвечает за обновление
        public void UpdateSpreadField(bool isActive)
        {
            
        }


        //Метод отвечает за сброс параметров 
        public void ResetSpreadField()
        {
            
        }


        //Метод, возвращающий направленный (от угла) вектор
        private Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
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