using TMPro;
using UnityEngine;

namespace Scripts.Conversation
{
    public class ConversationElement : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _elementTextComponent;

        public void OnShow(string elementText)
        {
            _elementTextComponent.text = elementText;
        }
    }
}