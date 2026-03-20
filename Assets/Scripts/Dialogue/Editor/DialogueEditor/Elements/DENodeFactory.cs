using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class DENodeFactory
{
    private static Dictionary<Type, Type> map;

    static DENodeFactory()
    {
        map = new Dictionary<Type, Type>();

        var nodeTypes = TypeCache.GetTypesDerivedFrom<BaseGraphNode>();

        foreach (var nodeType in nodeTypes)
        {
            var attr = (GraphNodeForAttribute)Attribute.GetCustomAttribute(
                nodeType, typeof(GraphNodeForAttribute));

            if (attr != null)
                map[attr.DataType] = nodeType;
        }
    }
    public static BaseGraphNode CreateNode(BaseNodeData data)
    {
        Type dataType = data.GetType();

        if (!map.TryGetValue(dataType, out Type nodeType))
        {
            Debug.LogError($"No GraphNode found for data type {dataType}");
            return null;
        }

        BaseGraphNode node = (BaseGraphNode)Activator.CreateInstance(nodeType);

        node.Initialize(data);
        node.Draw();

        return node;
    }

    public static Dictionary<Type, Type> GetRegisteredDataTypes()
    {
        return map;
    }
}
