using UnityEngine;

namespace Scripts.Conversation
{
    public class ConversationRemark : ConversationElement
    {
        public void SetColor(Color color)
        {
            _elementTextComponent.color = color;
        }
    }
}