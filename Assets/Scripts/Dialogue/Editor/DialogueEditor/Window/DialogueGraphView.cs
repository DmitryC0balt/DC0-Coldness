using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueGraphView : GraphView
{
    public Dictionary<string, BaseGraphNode> nodeInfo;
    private DESearchWindow searchWindow;
    private MiniMap miniMap;
    public DialogueGraphView()
    {
        nodeInfo = new Dictionary<string, BaseGraphNode>();

        searchWindow = ScriptableObject.CreateInstance<DESearchWindow>();
        searchWindow.Initialize(this);

        graphViewChanged += OnGraphViewChanged;
        nodeCreationRequest = context =>
        {
            SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), searchWindow);
        };

        miniMap = new MiniMap
        {
            anchored = true   
        };

        miniMap.SetPosition(new Rect(10, 30, 200, 140)); 
        Add(miniMap);

        AddManupulators();
        AddGidBackground();
        AddStyles();
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        List<Port> compatablePorts = new List<Port>();

        ports.ForEach(port => 
        {
            if (startPort != port && startPort.direction != port.direction && startPort.node != port.node && startPort.portType == port.portType) 
            {
                compatablePorts.Add(port);
            }
        });

        return compatablePorts;
    }

    public BaseGraphNode CreateNode(Type type, Vector2 position)
    {
        BaseGraphNode node = (BaseGraphNode)Activator.CreateInstance(type);

        
        node.Initialize(position);
        node.Draw();
        nodeInfo.Add(node.NodeId, node);

        AddElement(node);
        return node;
    }

    public BaseGraphNode CreateNode(BaseNodeData data)
    {
        BaseGraphNode node = DENodeFactory.CreateNode(data);
        nodeInfo.Add(node.NodeId, node);
        return node;
    }

    private void AddGidBackground()
    {
        GridBackground background = new GridBackground();

        background.StretchToParentSize();
        Insert(0, background);
    }
    private void AddStyles()
    {
        StyleSheet BaseStyleSheet = (StyleSheet) EditorGUIUtility.Load("DialogueEditor/DEGraphView.uss");
        StyleSheet NodeStyleSheet = (StyleSheet)EditorGUIUtility.Load("DialogueEditor/DENode.uss");

        styleSheets.Add(BaseStyleSheet);
        styleSheets.Add(NodeStyleSheet);
        
    }
    private void AddManupulators()
    {
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new ContentZoomer());

        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new RectangleSelector());
    }

    public void CreateEdges()
    {
        foreach (var node in nodeInfo)
        {
            foreach (Edge edge in node.Value.DrawEdges(nodeInfo))
            {
                AddElement(edge);
                RegisterEdgeCallbacks(edge);
            }
        }
    }

    private GraphViewChange OnGraphViewChanged(GraphViewChange change)
    {
        if (change.edgesToCreate != null)
        {
            foreach (Edge edge in change.edgesToCreate)
            {
                RegisterEdgeCallbacks(edge);
            }
        }

        return change;
    }

    private void RegisterEdgeCallbacks(Edge edge)
    {
        edge.RegisterCallback<MouseDownEvent>(evt =>
        {
            if (evt.clickCount == 2)
            {
                Vector2 pos = evt.localMousePosition;
                CreateRerouteNodeOnEdge(edge, pos);
                evt.StopPropagation();
            }
        });
    }

    private void CreateRerouteNodeOnEdge(Edge edge, Vector2 mousePos)
    {
        Port outputPort = edge.output;
        Port inputPort = edge.input;

        edge.output.Disconnect(edge);
        edge.input.Disconnect(edge);
        RemoveElement(edge);

        DERouteNode reroute = new DERouteNode();
        reroute.Initialize(edge, mousePos);
        reroute.Draw();
        AddElement(reroute);

        reroute.SetPosition(new Rect(mousePos, Vector2.zero));

        Edge e1 = outputPort.ConnectTo(reroute.inputPort);
        Edge e2 = reroute.outputPort.ConnectTo(inputPort);

        AddElement(e1);
        AddElement(e2);

        RegisterEdgeCallbacks(e1);
        RegisterEdgeCallbacks(e2);
    }

    public void ToggleMiniMap()
    {
        miniMap.visible = !miniMap.visible;
    }
}
