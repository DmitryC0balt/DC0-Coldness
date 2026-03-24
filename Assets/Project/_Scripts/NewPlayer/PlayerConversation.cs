using System.Collections.Generic;
using Scripts.EntryPoint;
using Scripts.NPC;


namespace Scripts.NewPlayer
{
    public class PlayerConversation
    {
        private GameEntryPoint _instance;

        private List<NpcHandler> _npcHandlerList;
        private float _conversationDistance;



        public PlayerConversation(PlayerConversationSetup playerConversationSetup)
        {
            
        }


        public bool TryGetNearestTarget()
        {
            return false;
        }


        public void StartConversation()
        {
            
        }

    }

}