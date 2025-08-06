using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class InterfaceAttribute : PropertyAttribute
{
    public Type interfaceType;

    public InterfaceAttribute(Type type)
    {
        Debug.Assert(type.IsInterface, $"{nameof(type)} needs to be an interface.");
        interfaceType = type;
    }
}