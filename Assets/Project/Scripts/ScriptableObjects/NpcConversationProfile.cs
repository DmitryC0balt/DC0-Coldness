using UnityEngine;

namespace Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NpcConversationProfile", menuName = "Scriptable Objects/NpcConversationProfile")]
    public class NpcConversationProfile : ScriptableObject
    {
        public string npcName;
        public Sprite npcPortrait;
    }
}