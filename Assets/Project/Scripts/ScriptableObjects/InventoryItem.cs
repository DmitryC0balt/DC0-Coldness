using UnityEngine;

namespace Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "Scriptable Objects/InventoryItem")]
    public class InventoryItem : ScriptableObject
    {
        public string ItemID;
        public string Name;
        public string Description;
        public Sprite Icon;
    }
}