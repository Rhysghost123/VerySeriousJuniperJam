using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Assets/Buff Database")]
public class BuffDatabase : ScriptableObject
{
    public BuffData[] buffs;

    public int GetBuffsCount()
    {
        int count = 0;

        foreach (var buff in buffs)
        {
            if (buff.type == BuffType.Buff)
                count++;
        }

        return count;
    }

    public int GetDebuffsCount()
    {
        int count = 0;

        foreach (var buff in buffs)
        {
            if (buff.type == BuffType.Debuff)
                count++;
        }

        return count;
    }

    public BuffData[] GetAllBuffs()
    {
        List<BuffData> result = new List<BuffData>();

        foreach (var data in buffs)
        {
            if (data.type == BuffType.Buff)
                result.Add(data);
        }

        return result.ToArray();
    }

    public BuffData[] GetAllDebuffs()
    {
        List<BuffData> result = new List<BuffData>();

        foreach (var data in buffs)
        {
            if (data.type == BuffType.Debuff)
                result.Add(data);
        }

        return result.ToArray();
    }
}