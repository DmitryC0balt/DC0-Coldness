using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DEItemPath
{
    public Port outPutport;
    public string nextNodeId;

    public ScriptableObject item;

    public DEItemPath() { }

    public DEItemPath(ItemPathData data)
    {
        nextNodeId = data.nextNodeId;
        item = data.item;
    }
}
