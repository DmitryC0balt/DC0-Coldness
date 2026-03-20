using UnityEngine;
using UnityEngine.UIElements;

public class HasItemCondition : BaseDialogueCondition
{
    public string Item;
    public int Amount;
    public override bool Evaluate()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialize()
    {
        Name = "Has Item";
    }
}
