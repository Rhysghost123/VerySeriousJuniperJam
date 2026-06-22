using UnityEngine;
using System.Collections.Generic;
using System;

public static class BuffManager
{
    private static readonly Dictionary<BuffableStats, StatLayer> _layers = new();

    private static readonly StatLayer _regenLayer = new();

    public static void Apply(BuffData chosen, bool isDebuff)
    {
        var pc = PlayerUtils.GetPlayerController();
        float mul = isDebuff ? 2f : 0.5f;   // TODO: drive from chosen.baseValue for per-asset potency

        StatLayer layer = GetOrCreate(chosen.stat, pc);
        var entry = new BuffEntry(mul);
        layer.active.Add(entry);

        // Health buffs also scale regen speed.
        BuffEntry regenEntry = null;
        if (chosen.stat == BuffableStats.Health)
        {
            EnsureRegenBase(pc);
            regenEntry = new BuffEntry(mul);
            _regenLayer.active.Add(regenEntry);
        }

        Recalculate(chosen.stat, pc);

        TimeUtils.StartCountdown(chosen.durationSeconds, () =>
        {
            layer.active.Remove(entry);
            regenEntry?.Let(e => _regenLayer.active.Remove(e));
            Recalculate(chosen.stat, pc);
        });
    }

    private class BuffEntry { public float multiplier; public BuffEntry(float m) => multiplier = m; }

    private class StatLayer
    {
        public float baseValue;
        public bool baseCaptured;
        public readonly List<BuffEntry> active = new();

        public float Combined()
        {
            float r = 1f;
            foreach (var e in active) r *= e.multiplier;
            return r;
        }
    }

    private static StatLayer GetOrCreate(BuffableStats stat, PlayerController pc)
    {
        if (!_layers.TryGetValue(stat, out var layer))
        {
            layer = new StatLayer { baseValue = ReadBase(stat, pc), baseCaptured = true };
            _layers[stat] = layer;
        }
        return layer;
    }

    private static float ReadBase(BuffableStats stat, PlayerController pc) => stat switch
    {
        BuffableStats.Speed => pc.GetMoveSpeed(),
        BuffableStats.Health => pc.GetMaxHealth(),
        BuffableStats.GoodLuckMultiplier => pc.GetGoodLuckMultiplier(),
        _ => 0f
    };

    private static void EnsureRegenBase(PlayerController pc)
    {
        if (!_regenLayer.baseCaptured)
        {
            _regenLayer.baseValue = pc.GetRegenSpeed();
            _regenLayer.baseCaptured = true;
        }
    }

    private static void Recalculate(BuffableStats stat, PlayerController pc)
    {
        var layer = _layers[stat];
        switch (stat)
        {
            case BuffableStats.Speed:
                pc.SetMoveSpeed(layer.baseValue * layer.Combined());
                break;

            case BuffableStats.Health:
                pc.SetMaxHealth((int)Mathf.Round(layer.baseValue * layer.Combined()));
                pc.SetRegenSpeed(_regenLayer.baseValue * _regenLayer.Combined());
                break;

            case BuffableStats.GoodLuckMultiplier:
                pc.SetGoodLuckMultiplier(layer.baseValue * layer.Combined());
                break;
        }
    }
}
internal static class ObjectExt
{
    public static void Let<T>(this T obj, System.Action<T> action) where T : class
    {
        if (obj != null) action(obj);
    }
}
public static class Buffs
{
    public static void ApplyRandomBuff() => ApplyRandom(isDebuff: false);
    public static void ApplyRandomDebuff() => ApplyRandom(isDebuff: true);

    private static void ApplyRandom(bool isDebuff)
    {
        var db = BuffDatabaseRuntime.Instance;
        var available = isDebuff ? db.GetAllDebuffs() : db.GetAllBuffs();
        if (available.Length == 0) return;

        var chosen = available[UnityEngine.Random.Range(0, available.Length)];
        BuffManager.Apply(chosen, isDebuff);
    }
}