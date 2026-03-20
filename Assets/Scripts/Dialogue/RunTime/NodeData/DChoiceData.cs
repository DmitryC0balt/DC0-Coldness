using System;
using UnityEngine;
[Serializable]
public class DChoiceData
{
    public string Text;
    public string NextNodeId;
    public string ConditionNodeId;
    [SerializeReference]
    public BaseDialogueCondition visibilityCondition;
}
