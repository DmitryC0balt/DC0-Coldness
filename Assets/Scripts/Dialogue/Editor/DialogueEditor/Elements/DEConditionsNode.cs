using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
[GraphNodeFor(typeof(ConditionsNodeData))]
public class DEConditionsNode : BaseGraphNode
{
    public ConditionsNodeData ConditionsData;
    
    private Foldout conditionsFoldout;
    private Port resultsPort;

    public override void Initialize(Vector2 position)
    {
        NodeName = "Conditions";
        ConditionsData = new ConditionsNodeData();
        ConditionsData.Conditions = new List<BaseDialogueCondition>();

        base.Initialize(position);
    }

    public override void Initialize(BaseNodeData data)
    {
        ConditionsData = (ConditionsNodeData) data;
        NodeName = data.Name;

        base.Initialize(data);
    }

    public override void Draw()
    {
        conditionsFoldout = new Foldout()
        {
            text = "Conditions"
        };

        Button createConditionButton = new Button()
        {
            text = "Add Condition"
        };
        createConditionButton.clicked += ShowAddEventMenu;

        conditionsFoldout.Add(createConditionButton);
        extensionContainer.Add(conditionsFoldout);

        resultsPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
        resultsPort.name = "Result";
        resultsPort.portColor = Color.darkRed;
        outputContainer.Add(resultsPort);

        foreach (var condition in ConditionsData.Conditions)
        {
            DrawCondition(condition);
        }

        base.Draw();
    }

    public void ShowAddEventMenu()
    {
        GenericMenu menu = new GenericMenu();

        foreach (Type type in ConditionsTypeCache.ConditionTypes)
        {
            menu.AddItem(
                new GUIContent(type.Name),
                false,
                () => AddCondition(type)
            );
        }

        menu.ShowAsContext();
    }

    private void AddCondition(Type type)
    {
        BaseDialogueCondition condition = (BaseDialogueCondition)Activator.CreateInstance(type);
        ConditionsData.Conditions.Add(condition);

        DrawCondition(condition);
    }

    private void DrawCondition(BaseDialogueCondition condition)
    {
        condition.Initialize();
        VisualElement container = container = new Foldout()
        {
            text = condition.GetName(),
        };
        Button button = new Button()
        {
            text = "X"
        };
        container.Q<Toggle>().Add(button);
        UIFactory.DrawFieldsReflectively(condition, container);
        Button removebutton = container.Q<Button>();

        removebutton.clicked += () => { RemoveCondition(condition, container); };

        conditionsFoldout.Add(container);
    }

    private void RemoveCondition(BaseDialogueCondition condition, VisualElement container)
    {
        ConditionsData.Conditions.Remove(condition);

        conditionsFoldout.Remove(container);
    }

    public override BaseNodeData Serialize()
    {
        ConditionsData.Name = NodeName;
        ConditionsData.NodeID = NodeId;
        ConditionsData.position = GetPosition().position;
        return ConditionsData;
    }

    public override Port GetOutputPort()
    {
        return resultsPort;
    }
}
