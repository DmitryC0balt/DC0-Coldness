using Scripts.MonoCash.Tier1;
using UnityEngine;


namespace Scripts.CameraMovement
{
    public class CameraHandler : MonoCashListener
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _target;
        [SerializeField] private CameraSetupStruct _cameraSetupStruct;


        public void SetCamera(Camera camera)
        {
            _camera = camera;
        }


        public override void OnInitialization()
        {
            SetPosition();
        }


        public override void OnFixedProcess()
        {
            MoveToPosition();
        }


        private void SetPosition()
        {
            _camera.transform.position = new Vector3
            (
                _target.position.x,
                _target.position.y + _cameraSetupStruct.heigth,
                _target.position.z - _cameraSetupStruct.depth
            );
        }


        private void MoveToPosition()
        {
            var currentPosition = new Vector3
            (
                _target.position.x,
                _target.position.y + _cameraSetupStruct.heigth,
                _target.position.z - _cameraSetupStruct.depth
            );

            _camera.transform.position = Vector3.Lerp(_camera.transform.position, currentPosition, Time.deltaTime * _cameraSetupStruct.smoothness);
        }
    }


    [System.Serializable]
    public struct CameraSetupStruct
    {
        public float heigth;
        public float depth;
        public float smoothness;
    }
}