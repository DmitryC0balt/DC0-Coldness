using UnityEngine;



namespace Scripts.NPC
{
    public class NpcTriggerHandler : MonoBehaviour
    {
        public bool isActivated{ get; private set;}
        private SphereCollider _sphereCollider;


        public void OnInitialization()
        {
            isActivated = false;
            _sphereCollider = GetComponent<SphereCollider>();
        }

        public void OnActivate() => isActivated = true;

        public void ResetCollider() => isActivated = false;

    }
}