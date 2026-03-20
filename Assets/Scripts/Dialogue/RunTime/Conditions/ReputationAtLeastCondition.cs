using UnityEngine;

public class ReputationAtLeastCondition : BaseDialogueCondition
{
    public string Character;
    public int Reputation;
    public override bool Evaluate()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialize()
    {
        Name = "Reputation atleast";
    }
}
