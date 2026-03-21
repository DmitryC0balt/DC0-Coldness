using Scripts.Conversation;
using UnityEngine;

namespace Scripts.EntryPoint
{
    [RequireComponent(typeof(ConversationHandler))]
    public class ConversationEntryPoint : SceneEntryPoint
    {
        [SerializeField] private ConversationHandler _conversationHandler;


        public override void OnSceneEnter()
        {
            _conversationHandler = GetComponent<ConversationHandler>();
            _conversationHandler.SetupConversation();
        }


        public override void OnSceneExit()
        {
            _conversationHandler.ResetConversation();
        }
    }
}