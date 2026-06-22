using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using UnityEngine;

public static class ControllerRegistry
{
    private static readonly List<MonoBehaviour> registry = new();

    public static void Register(MonoBehaviour controller)
    {
        if (!registry.Contains(controller))
            registry.Add(controller);
    }

    public static void Unregister(MonoBehaviour controller)
    {
        registry.Remove(controller);
    }

    public static T Get<T>() where T : MonoBehaviour
    {
        foreach (var controller in registry)
        {
            if (controller is T typed)
                return typed;
        }

        return null;
    }
}