using System;
[Serializable]
public abstract class BaseDialogueCondition
{
    protected string Name;
    public abstract bool Evaluate();
    public abstract void Initialize();

    public string GetName()
    {
        return Name;
    }
}
