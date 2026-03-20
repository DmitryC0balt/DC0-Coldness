using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueGraph")]
public class DialogueData : ScriptableObject
{
    [SerializeReference]
    public List<BaseNodeData> nodes;
}