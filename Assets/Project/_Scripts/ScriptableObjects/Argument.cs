using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Argument", menuName = "Scriptable Objects/Argument")]
    public class Argument : ScriptableObject
    {
        public string id;
        public string argumentName;
        public string description;
        public List<Argument> possibleArgumentConnections;
    }
}