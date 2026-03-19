using Scripts.MonoCash.Tier1;
using Scripts.ScriptableObjects;
using UnityEngine;

namespace Scripts.NPC
{
    [RequireComponent(typeof(CharacterController))]
    public class NpcHandler : MonoCashListener
    {
        private CharacterController _characterController;
        [Header("NPC's Health")]
        [SerializeField] private NpcHealthSetup _npcHealthSetup;
        [SerializeField] private NpcConversationProfile _npcConversationProfile;
        [Space(5)]

        [Header("NPC's states setup")]
        [SerializeField] private NpcCalmStateSetup _npcCalmStateSetup;
        [SerializeField] private NpcPanicStateSetup _npcPanicStateSetup;



        public NpcConversationProfile npcConversationProfile => _npcConversationProfile;



        public override void OnInitialization()
        {
            
        }


        public override void OnProcess()
        {
        
        }


        public override void OnFixedProcess()
        {
            
        }
    }


    [System.Serializable]
    public struct NpcHealthSetup
    {
        public int maxHealth;
    }



    [System.Serializable]
    public struct NpcCalmStateSetup
    {
        public float movementSpeed;
        public float angularSpeed;
    }


    [System.Serializable]
    public struct NpcPanicStateSetup
    {
        public float movementSpeed;
        public float angularSpeed;
    }
}