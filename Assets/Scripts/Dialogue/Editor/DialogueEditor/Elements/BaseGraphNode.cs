using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

[GraphNodeFor(typeof(BaseNodeData))]
public class BaseGraphNode : Node
{
    public string NodeId { get; set; }
    public string NodeName { get; set; }

    public virtual void Initialize(Vector2 position)
    {
        SetPosition(new Rect(position, Vector2.zero));
        NodeId = Guid.NewGuid().ToString();
    }

    public virtual void Initialize(BaseNodeData data)
    {
        SetPosition(new Rect(data.position, Vector2.zero));
        NodeId = data.NodeID;
    }

    public virtual void Draw()
    {
        TextField titleTextField = new TextField()
        {
            value = NodeName
        };

        titleContainer.Insert(0, titleTextField);

        RefreshExpandedState();
    }

    public virtual List<Edge> DrawEdges(Dictionary<string, BaseGraphNode> nodeInfo) {
        return null;
    }

    public virtual BaseNodeData Serialize() 
    {
        return new BaseNodeData() 
        {
            NodeID = NodeId,
            Name = NodeName,
        };
    }

    public virtual Port GetInputPort() 
    {
        return null;
    }

    public virtual Port GetOutputPort()
    {
        return null;
    }
}
