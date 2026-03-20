using System;
using UnityEngine;
using UnityEngine.UIElements;
[Serializable]
public class ChangeFlagDEvent : BaseDialogueEvent
{
    public string FlagName;
    public bool Value;

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialize()
    {
        Name = "Change Flag";
    }
}
