using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class GiveItemDEvent : BaseDialogueEvent
{
    public string itemId;
    public int amount = 1;

    public override void Execute()
    {
        Debug.Log($"Giving item: {itemId}");
    }

    public override void Initialize()
    {
        Name = "Give Item";
    }
}
