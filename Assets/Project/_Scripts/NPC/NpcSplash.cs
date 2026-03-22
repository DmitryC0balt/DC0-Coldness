using UnityEngine.UI;
using UnityEngine;

namespace Scripts.NPC
{
    public class NpcSplash : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private GameObject _splash;
        [SerializeField] private Image _splashImage;


        public void Initialization()
        {
            _camera = Camera.main;
        }


        public void Rotation()
        {
            
        }


        public void Show(bool isActive) => _splashImage.gameObject.SetActive(isActive);

    }

}