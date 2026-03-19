using UnityEngine;

namespace Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Record", menuName = "Scriptable Objects/Record")]
    public class Record : ScriptableObject
    {
        public CharacterRecord character;

        public string id;
        public string characterName;
        public string description;
    }
}