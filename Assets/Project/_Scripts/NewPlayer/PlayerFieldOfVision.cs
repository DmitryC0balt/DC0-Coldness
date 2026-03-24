using UnityEngine;

namespace Scripts.NewPlayer
{
    public class PlayerFieldOfVision : MonoBehaviour
    {
        [SerializeField] private float _range;//Дальность
        [SerializeField] private float _angle;//Угол
        [SerializeField] private float _directionAngle;
        [SerializeField] private LayerMask _objectLayer;//Слой взаимодействия
        [SerializeField] private int _rayCount;


        private Mesh _mesh;
        private MeshFilter _meshFilter;
        private float _currentAngle;
        private Vector3 _origin;


        private const int _borderRayCount = 2;
        private const int _triangleVerticesCount = 3;
        private const int _defaultVertexIndex = 1;
        private const int _defaultTriangleIndex = 0;


        //private void Start() => OnInitialization();

        //private void LateUpdate() => OnPostProcess();



        public void OnInitialization()
        {
            _mesh = new Mesh();
            _meshFilter = GetComponent<MeshFilter>();
            _meshFilter.mesh = _mesh;
            _origin = Vector3.zero;

            _currentAngle = 0;
        }


        public void OnPostProcess()
        {
            DrawSpreadField();
        }


        private void DrawSpreadField()
        {
            var currentAngle = _currentAngle;
            var angleIncrease = _angle / _rayCount;

            Vector3[] vertices = new Vector3[_rayCount + _borderRayCount];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[_rayCount * _triangleVerticesCount];

            vertices[0] = _origin;

            int vertexIndex = _defaultVertexIndex;
            int triangleIndex = _defaultTriangleIndex;

            for (int i = 0; i <= _rayCount; i++)
            {
                var direction = GetVector3FromAngle(currentAngle);
                Vector3 vertex;

                RaycastHit hit;

                //Проверка луча на столкновение с  предметами
                if (Physics.Raycast(_origin, direction, out hit, _range, _objectLayer))
                {
                    //Есть стокновение
                    vertex = hit.point;
                }
                else
                {
                    //Нет столкновения
                    vertex = _origin + direction * _range;
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
                currentAngle -= angleIncrease;
            }

            _mesh.vertices = vertices;
            _mesh.uv = uv;
            _mesh.triangles = triangles;
        }


        private Vector3 GetVector2FromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }


        private Vector3 GetVector3FromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180);
            return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
        }


        private float GetAngleFromVector3(Vector3 vector)
        {
            vector = vector.normalized;
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }


        public void SetDirection(Vector3 direction)
        {
            var currentDirection = new Vector3(direction.x, 0, direction.z);
            _currentAngle = GetAngleFromVector3(currentDirection) - _angle / 2;
        }


        public void SetOrigin(Vector3 origin)
        {
            _origin = origin;
        }
    }
}