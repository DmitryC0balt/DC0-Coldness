using UnityEngine;


namespace Scripts.Player.FOV
{
    public class FieldOfVision : MonoBehaviour
    {
        [SerializeField] private FieldOfVisionSetup _fieldOfVisionSetup;


        public void ShowSpreadField(bool isActive)
        {
            gameObject.SetActive(isActive);
        }


        public void DrawSpreadField()
        {
            
        }


        public void UpdateSpreadField()
        {
            
        }


        public void ResetSpreadField()
        {
            
        }
    }


    [System.Serializable]
    public struct FieldOfVisionSetup
    {
        
    }
}