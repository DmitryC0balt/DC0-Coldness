using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[GraphNodeFor(typeof(LineNodeData))]
public class DELineNode : BaseGraphNode
{
    public List<DEChoice> Choices { get; set; }
    public string Text { get; set; }
    public List<BaseDialogueEvent> Events { get; set; }
    public List<DEItemPath> ItemPaths { get; set; }
    public DEItemPath defaultItempath;
    public Port inputPort;
    private VisualElement upperContainer;
    private Foldout eventFoldout;

    private VisualElement choiceBox;
    private VisualElement itemPathBox;

    public override void Initialize(Vector2 position)
    {
        Events = new List<BaseDialogueEvent>();
        Choices = new List<DEChoice>();
        ItemPaths = new List<DEItemPath>();

        Text = "Line Text";
        NodeName = "Line Title";

        Choices.Add(new DEChoice());

        extensionContainer.AddToClassList("de-node_extension-container");

        base.Initialize(position);
    }

    public override void Initialize(BaseNodeData data)
    {
        LineNodeData lineNodeData = data as LineNodeData;

        if (lineNodeData != null) 
        {
            Events = lineNodeData.Events;
            Text = lineNodeData.Text;
            NodeName = lineNodeData.Name;
            Choices = new List<DEChoice>();
            foreach (var choice in lineNodeData.Choices) 
            {
               Choices.Add(new DEChoice(choice));
            }
            ItemPaths = new List<DEItemPath>();
            foreach(var path in lineNodeData.ItemPaths)
            {
                ItemPaths.Add(new DEItemPath(path));
            }
        }

        extensionContainer.AddToClassList("de-node_extension-container");

        base.Initialize(data);
    }


    public override void Draw()
    {
        choiceBox = new VisualElement();
        itemPathBox = new VisualElement();

        outputContainer.Add(choiceBox);
        outputContainer.Add(itemPathBox);

        DrawHeader();
        DrawTextContainer();

        foreach (DEChoice choice in Choices)
        {
            DrawChoice(choice);
        }

        Button createChoiceButton = new Button()
        {
            text = "Add Choice",
        };
        createChoiceButton.clicked += AddChoice;

        upperContainer.Add(createChoiceButton);

        DrawEventContainer();

        foreach (BaseDialogueEvent vnt in Events)
        {
            DrawEvent(vnt);
        }

        DrawDefaultItemPath();

        foreach (DEItemPath path in ItemPaths)
        {
            DrawItemPath(path);
        }

        RefreshExpandedState();
    }

    private void DrawEventContainer()
    {
        Button createEventButton = new Button()
        {
            text = "Add Event"
        };
        createEventButton.clicked += ShowAddEventMenu;
        eventFoldout = new Foldout()
        {
            text = "Events",
            value = false
        };
        eventFoldout.AddToClassList("de-node_data-container");
        eventFoldout.Add(createEventButton);

        extensionContainer.Add(eventFoldout);
    }

    private void DrawTextContainer()
    {
        Foldout textFoldout = new Foldout()
        {
            text = "Line Text",
            value = false
        };

        TextField lineText = new TextField()
        {
            value = Text,
            multiline = true,
        };
        lineText.RegisterValueChangedCallback(x => { Text = x.newValue; });

        lineText.AddToClassList("de-node_text-field");
        lineText.AddToClassList("de-node_line_text-field");

        textFoldout.Add(lineText);
        textFoldout.AddToClassList("de-node_data-container");
        extensionContainer.Add(textFoldout);
    }

    private void DrawHeader()
    {
        upperContainer = new VisualElement();
        mainContainer.Insert(1, upperContainer);

        TextField titleTextField = new TextField()
        {
            value = NodeName
        };
        titleTextField.RegisterValueChangedCallback(x => { NodeName = x.newValue; });

        //titleTextField.AddToClassList("de-node_text-field");
        titleTextField.AddToClassList("de-node_title-text-field");
        titleContainer.Insert(0, titleTextField);

        inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(DELineNode));
        inputPort.portName = "In";
        inputPort.portColor = Color.lightBlue;
        upperContainer.Insert(0, inputPort);

        Button addItemPathButton = new Button()
        {
            text = "Add Item Path",
        };
        addItemPathButton.clicked += AddItemPath;

        upperContainer.Add(addItemPathButton);
    }

    private void DrawDefaultItemPath()
    {
        defaultItempath = new DEItemPath();
        defaultItempath.outPutport = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(DELineNode));
        defaultItempath.outPutport.portColor = Color.lightBlue;
        defaultItempath.outPutport.portName = "Default Item Path";

        itemPathBox.Add(defaultItempath.outPutport);
    }

    public void AddItemPath()
    {
        DEItemPath itemPath = new DEItemPath();
        ItemPaths.Add(itemPath);
        DrawItemPath(itemPath);
    }

    public void DrawItemPath(DEItemPath itemPath)
    {
        Button removePathButton = new Button()
        {
            text = "X"
        };
        ObjectField objectField = new ObjectField()
        {
            label = "Item"
        };
        itemPath.outPutport = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(DELineNode));
        itemPath.outPutport.portName = "";
        itemPath.outPutport.portColor = Color.lightBlue;
        removePathButton.clicked += () => { RemoveItemPath(itemPath, itemPath.outPutport); };

        itemPath.outPutport.Add(objectField);
        itemPath.outPutport.Add(removePathButton);

        itemPathBox.Add(itemPath.outPutport);
    }
    
    public void RemoveItemPath(DEItemPath itemPath, VisualElement container)
    {
        ItemPaths.Remove(itemPath);
        itemPathBox.Remove(container);
    }

    public void AddChoice()
    {
        DEChoice choice = new DEChoice();
        Choices.Add(choice);
        DrawChoice(choice);
    }

    public void RemoveChoice(DEChoice choice, Port inputPort, Port outputPort)
    {
        Choices.Remove(choice);
        inputContainer.Remove(inputPort);
        choiceBox.Remove(outputPort);

        foreach (var edge in inputPort.connections.ToList())
        {
            edge.RemoveFromHierarchy();
            
        }
            

        foreach (var edge in outputPort.connections.ToList())
            edge.RemoveFromHierarchy();

        RefreshPorts();
        RefreshExpandedState();
    }

    private void DrawChoice(DEChoice choice)
    {
        Port outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(DELineNode));
        outputPort.portName = "";
        outputPort.portColor = Color.lightBlue;
        Button deleteButton = new Button() 
        { 
            text = "X",
        };
        
        TextField textField = new TextField() 
        {
            value = choice.Text
        };
        textField.RegisterValueChangedCallback(x => { choice.Text = x.newValue; });
        textField.AddToClassList("de-node_text-field");
        textField.AddToClassList("de-node_choice-text-field");

        outputPort.Add(textField);
        outputPort.Add(deleteButton);

        choiceBox.Add(outputPort);

        Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        inputPort.portName = "Conditions";
        inputPort.portColor = Color.darkRed;
        inputContainer.Add(inputPort);

        deleteButton.clicked += () => RemoveChoice(choice, inputPort, outputPort);

        choice.inPort = inputPort;
        choice.outPort = outputPort;
    }

    public void ShowAddEventMenu()
    {
        GenericMenu menu = new GenericMenu();

        foreach (Type type in EventTypeCache.EventTypes)
        {
            menu.AddItem(
                new GUIContent(type.Name),
                false,
                () => AddEvent(type)
            );
        }

        menu.ShowAsContext();
    }

    private void AddEvent(Type type)
    {
        BaseDialogueEvent newEvent = (BaseDialogueEvent)Activator.CreateInstance(type);

        Events.Add(newEvent);

        DrawEvent(newEvent);
    }

    private void DrawEvent(BaseDialogueEvent newEvent)
    {
        newEvent.Initialize();
        VisualElement container = new Foldout()
        {
            text = newEvent.GetName(),
        };
        Button button = new Button()
        {
            text = "X"
        };
        container.Q<Toggle>().Add(button);
        UIFactory.DrawFieldsReflectively(newEvent, container);
        Button removeButton = container.Q<Button>();

        removeButton.clicked += () => { RemoveEvent(newEvent, container); };


        eventFoldout.Add(container);
    }

    private void RemoveEvent(BaseDialogueEvent dEvent, VisualElement container) 
    { 
        Events.Remove(dEvent);

        eventFoldout.Remove(container);
    }

    public override List<Edge> DrawEdges(Dictionary<string, BaseGraphNode> nodeInfo)
    {
        List<Edge> edges = new List<Edge>();
        foreach (DEChoice choiceData in Choices)
        {
            if (!string.IsNullOrEmpty(choiceData.NextNodeId) && !choiceData.outPort.connected)
            {
                Edge outEdge = choiceData.outPort.ConnectTo(nodeInfo[choiceData.NextNodeId].GetInputPort());
                edges.Add(outEdge);
                
            }
            if (!string.IsNullOrEmpty(choiceData.ConditionNodeId) && !choiceData.inPort.connected)
            {
                Edge inEdge = choiceData.inPort.ConnectTo(nodeInfo[choiceData.ConditionNodeId].GetOutputPort());
                edges.Add(inEdge);
                
            }
        }

        return edges;
    }

    public override BaseNodeData Serialize()
    {
        List<DChoiceData> dChoices = new List<DChoiceData>();
        foreach (DEChoice choice in Choices)
        {
            dChoices.Add(choice.Serialize());
        }
        return new LineNodeData() 
        {
            NodeID = NodeId,
            Name = NodeName,
            Choices = dChoices,
            Events = Events,
            position = GetPosition().position,
            Text = Text,
        };
    }

    public override Port GetInputPort()
    {
        return inputPort;
    }
}
