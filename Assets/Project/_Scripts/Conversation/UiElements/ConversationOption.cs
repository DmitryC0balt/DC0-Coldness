namespace Scripts.Conversation
{
    public class ConversationOption : ConversationElement
    {
        public string nextNodeID{get; private set;}

        public void SetNextNodeID(string nodeID = null)
        {
            nextNodeID = nodeID;
        }
    }
}