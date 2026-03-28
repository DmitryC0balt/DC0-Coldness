using System.Collections;
using Scripts.MonoCash.Tier1;
using Scripts.ScriptableObjects;
using UnityEngine;

namespace Scripts.NPC
{
    [RequireComponent(typeof(Rigidbody))]
    public class NpcHandler : MonoCashListener
    {
        [Header("NPC's Health")]
        [SerializeField] private NpcHealthSetup _npcHealthSetup;
        [SerializeField] private NpcConversationProfile _npcConversationProfile;
        [Space(5)]

        
        [SerializeField] private NpcTriggerHandler _npcTriggerHandler;
        

        private bool _isAttacked = false;//Попадание в "сферу испуга"
        private bool _isShot = false;//Попадание в самого НПС
        [SerializeField] private bool _extraLive;



        public NpcConversationProfile npcConversationProfile => _npcConversationProfile;
        private NpcStateMashine _npcStateMashine;


        public override void OnInitialization()
        {
            _npcStateMashine = new NpcStateMashine();
        }


#region PROCESS_BLOCK

        public override void OnProcess()
        {
            if (isAttacked)
            {
                if (isShot)
                {
                    //Он умер
                    StartCoroutine(DestroyNpc());
                    return;
                }
                //паника
                return;
            }
        }


        public void GetInfo()
        {
            
        }



        public override void OnFixedProcess()
        {
            
            //Физ
        }


        public override void OnPostProcess()
        {
            //Анимация
        }

#endregion


        public void OnTriggerEnter()
        {
            
        }


        private IEnumerator DestroyNpc()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }


    [System.Serializable]
    public struct NpcHealthSetup
    {
        public int maxHealth;
    }



  
}