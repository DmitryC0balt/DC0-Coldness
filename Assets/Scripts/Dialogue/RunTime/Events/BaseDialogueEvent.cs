using System;
[Serializable]
public abstract class BaseDialogueEvent
{
    protected string Name;
    public abstract void Execute();
    public abstract void Initialize();

    public string GetName()
    {
        return Name;
    }
}
