using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public static class UIFactory
{
    public static void DrawFieldsReflectively(object obj, VisualElement root)
    {
        var fields = obj.GetType().GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);

        foreach (var field in fields)
        {
            if (!field.IsPublic && field.GetCustomAttribute<SerializeField>() == null)
                continue;

            VisualElement fieldUI = CreateFieldForType(field, obj);
            if (fieldUI != null)
                root.Add(fieldUI);
        }
    }

    private static VisualElement CreateFieldForType(FieldInfo field, object target)
    {
        Type type = field.FieldType;
        object value = field.GetValue(target);

        string label = ObjectNames.NicifyVariableName(field.Name);

        // INT
        if (type == typeof(int))
        {
            IntegerField f = new IntegerField(label) { value = (int)value };
            f.RegisterValueChangedCallback(e => field.SetValue(target, e.newValue));
            return f;
        }

        // FLOAT
        if (type == typeof(float))
        {
            FloatField f = new FloatField(label) { value = (float)value };
            f.RegisterValueChangedCallback(e => field.SetValue(target, e.newValue));
            return f;
        }

        // BOOL
        if (type == typeof(bool))
        {
            Toggle f = new Toggle(label) { value = (bool)value };
            f.RegisterValueChangedCallback(e => field.SetValue(target, e.newValue));
            return f;
        }

        // STRING
        if (type == typeof(string))
        {
            TextField f = new TextField(label) { value = (string)value };
            f.RegisterValueChangedCallback(e => field.SetValue(target, e.newValue));
            return f;
        }

        // ENUM
        if (type.IsEnum)
        {
            EnumField f = new EnumField(label, (Enum)value);
            f.RegisterValueChangedCallback(e => field.SetValue(target, e.newValue));
            return f;
        }

        return null;
    }
}
