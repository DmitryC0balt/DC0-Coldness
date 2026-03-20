using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

[GraphNodeFor(typeof(RouteNodeData))]
public class DERouteNode : BaseGraphNode
{
    public string inputNodeId;
    public Type Type;
    public string outputNodeId;
    public Color portColor;
    
    public Port outputPort;
    public Port inputPort;
    public override void Initialize(BaseNodeData data)
    {
        RouteNodeData routeNodeData = data as RouteNodeData;

        inputNodeId = routeNodeData.inputNodeId;
        outputNodeId = routeNodeData.outputNodeId;
        Type = routeNodeData.Type;
        portColor = routeNodeData.portColor;


        base.Initialize(data);
    }

    public void Initialize(Edge edge, Vector2 position)
    {
        NodeName = "Route Node";
        Type = edge.input.portType;
        portColor = edge.input.portColor;
        base.Initialize(position);
    }

    public override void Draw()
    {
        outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, Type);
        outputPort.portName = "";
        outputPort.portColor = portColor;
        inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, Type);
        inputPort.portName = "";
        inputPort.portColor = portColor;
        inputContainer.Add(inputPort);
        outputContainer.Add(outputPort);

        titleContainer.style.display = DisplayStyle.None;
    }

    public override Port GetInputPort()
    {
        return inputPort;
    }

    public override Port GetOutputPort()
    {
        return outputPort;
    }

    public void GetIds()
    {

    }

    public override List<Edge> DrawEdges(Dictionary<string, BaseGraphNode> nodeInfo)
    {
        List<Edge> edges = new List<Edge>();
        if (!outputPort.connected && !string.IsNullOrEmpty(outputNodeId))
        {
            Edge edge = outputPort.ConnectTo(nodeInfo[outputNodeId].GetInputPort());
            edges.Add(edge);
        }
        if (!inputPort.connected && !string.IsNullOrEmpty(inputNodeId))
        {
            Edge edge = inputPort.ConnectTo(nodeInfo[inputNodeId].GetOutputPort());
            edges.Add(edge);
        }

        return edges;
    }

    public override BaseNodeData Serialize()
    {
        return new RouteNodeData()
        {
            Name = NodeName,
            NodeID = NodeId,
            Type = Type,
            position = GetPosition().position,
            inputNodeId = ((BaseGraphNode) inputPort.connections.First().output.node).NodeId,
            outputNodeId = ((BaseGraphNode)outputPort.connections.First().input.node).NodeId,
            portColor = portColor,
        };
    }
}
