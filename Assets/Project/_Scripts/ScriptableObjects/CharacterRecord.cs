using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterRecord", menuName = "Scriptable Objects/CharacterRecord")]
    public class CharacterRecord : ScriptableObject
    {
        public string id;
        public string characterName;
        public Sprite characterPortrait;
        public string description;

        public List<Record> factsList;
    }
}