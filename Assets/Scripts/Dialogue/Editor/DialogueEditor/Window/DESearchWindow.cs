using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class DESearchWindow : ScriptableObject, ISearchWindowProvider
{
    private DialogueGraphView graphView;
    public void Initialize(DialogueGraphView graphView)
    {
        this.graphView = graphView;
    }
    public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
    {
        var tree = new List<SearchTreeEntry>
        {
            new SearchTreeGroupEntry(new GUIContent("Create Node"), 0)
        };

        foreach (var pair in DENodeFactory.GetRegisteredDataTypes())
        {
            Type dataType = pair.Value;

            tree.Add(new SearchTreeEntry(new GUIContent(dataType.Name))
            {
                level = 1,
                userData = dataType
            });
        }

        return tree;
    }

    public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
    {
        Vector2 worldMousePos = context.screenMousePosition;
        Vector2 localMousePos = graphView.contentViewContainer.WorldToLocal(worldMousePos);

        Type dataType = (Type)SearchTreeEntry.userData;

        graphView.CreateNode(dataType, localMousePos);
        return true;
    }
}
