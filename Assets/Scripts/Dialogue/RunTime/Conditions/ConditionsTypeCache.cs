using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConditionsTypeCache
{
    public static readonly List<Type> ConditionTypes;

    static ConditionsTypeCache()
    {
        ConditionTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t =>
                !t.IsAbstract &&
                typeof(BaseDialogueCondition).IsAssignableFrom(t))
            .ToList();
    }
}
