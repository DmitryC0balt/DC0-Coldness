using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[Serializable]
public class DEChoice
{
    public string Text;
    public string NextNodeId;
    public string ConditionNodeId;
    [SerializeReference]
    public BaseDialogueCondition visibilityCondition;

    [NonSerialized]
    public Port outPort;
    [NonSerialized]
    public Port inPort;

    public DEChoice()
    {
        Text = "New Choice";
    }
    public DEChoice(DChoiceData data)
    {
        Text = data.Text;
        NextNodeId = data.NextNodeId;
        ConditionNodeId = data.ConditionNodeId;
        visibilityCondition = data.visibilityCondition;
    }
    public void GetIds()
    {
        if (outPort.connected)
        {
            BaseGraphNode nextNode = (BaseGraphNode)outPort.connections.First().input.node;

            if (nextNode != null)
            {
                NextNodeId = nextNode.NodeId;
            }
        }
        else 
        {
            NextNodeId = null;
        }
        if (inPort.connected)
        {
            BaseGraphNode conditionNode = (BaseGraphNode) inPort.connections.First().output.node;

            if (conditionNode != null) 
            {
                ConditionNodeId = conditionNode.NodeId;
            }
        }
        else
        {
            ConditionNodeId = null;
        }
    }

    public DChoiceData Serialize()
    {
        GetIds();
        return new DChoiceData()
        {
            Text = Text,
            NextNodeId = NextNodeId,
            ConditionNodeId = ConditionNodeId,
            visibilityCondition = visibilityCondition,
        };
    }
}
