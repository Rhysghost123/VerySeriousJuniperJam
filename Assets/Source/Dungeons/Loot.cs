using System;
using UnityEngine;

public enum LootType
{
    WeaponUpgrade,
    Buff,
    Debuff,
    Jumpscare
}

public class Loot
{
    public static T RandomEnum<T>() where T : System.Enum
    {
        T[] values = (T[])System.Enum.GetValues(typeof(T));
        return values[UnityEngine.Random.Range(0, values.Length)];
    }
}