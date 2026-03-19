using UnityEngine;

namespace Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Objects/Quest")]
    public class Quest : ScriptableObject
    {
        public string id;
        public string description;
        public QuestStatus status;
    }


    public enum QuestStatus
    {
        active,
        done,
        failed
    }
}