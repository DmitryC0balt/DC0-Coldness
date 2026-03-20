using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EventTypeCache 
{
    public static readonly List<Type> EventTypes;

    static EventTypeCache()
    {
        EventTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t =>
                !t.IsAbstract &&
                typeof(BaseDialogueEvent).IsAssignableFrom(t))
            .ToList();
    }
}
