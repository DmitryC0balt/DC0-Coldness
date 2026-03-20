using System;

[AttributeUsage(AttributeTargets.Class)]
public class GraphNodeForAttribute : Attribute
{
    public Type DataType;

    public GraphNodeForAttribute(Type dataType)
    {
        DataType = dataType;
    }
}