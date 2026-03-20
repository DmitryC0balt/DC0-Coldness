using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LineNodeData : BaseNodeData
{
    public List<DChoiceData> Choices;
    [SerializeReference]
    public List<BaseDialogueEvent> Events;
    public List<ItemPathData> ItemPaths;
    public string Text;
}
