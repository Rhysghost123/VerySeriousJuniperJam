using UnityEngine;
using System;

public class Buffs
{
    public static void ApplyRandomBuff()
    {
        var BuffCount = BuffDatabaseRuntime.Instance.GetBuffsCount();
        var randomNum = Random.RandomMinMax<int>(0, BuffCount); // :(

        BuffData[] Available = BuffDatabaseRuntime.Instance.GetAllBuffs();

        // index into the array to chose one, wrap around modulo with the count.
        BuffData chosen = Available[randomNum % BuffCount];
    }
}