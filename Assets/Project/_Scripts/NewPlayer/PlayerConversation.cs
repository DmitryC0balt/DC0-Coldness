using System.Collections.Generic;
using Scripts.EntryPoint;
using Scripts.NPC;
using UnityEngine;


namespace Scripts.NewPlayer
{
    public class PlayerConversation
    {
        private GameEntryPoint _instance;
        private List<NpcHandler> _npcHandlerList;
        private float _conversationDistance;
        private LayerMask _npcLayer;

        private NpcHandler _currentNpcHandler;


        public PlayerConversation(PlayerConversationSetup playerConversationSetup)
        {
            _npcHandlerList = new List<NpcHandler>((int)playerConversationSetup.conversationCapacity);
            _conversationDistance = playerConversationSetup.conversationRadius;
            _npcLayer = playerConversationSetup.npcLayer;

            _instance = GameEntryPoint.GetInstance();
        }


        public bool TryGetNearestTarget(out NpcHandler nearestNpcHandler)
        {
            nearestNpcHandler = null;

            

            return false;
        }


        public void StartConversation()
        {
            
        }


        public void StopConversation()
        {
            
        }

    }

}