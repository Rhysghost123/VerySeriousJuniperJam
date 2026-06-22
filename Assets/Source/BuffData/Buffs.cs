using System.Collections.Generic;
using UnityEngine;
using System;

public static class BuffManager
{
    private static readonly Dictionary<BuffableStats, StatLayer> _layers = new();
    private static readonly StatLayer _regenLayer = new();

    public static void Apply(BuffData chosen, bool isDebuff)
    {
        var pc = PlayerUtils.GetPlayerController();
        float mul = isDebuff ? 2f : 0.5f;

        StatLayer layer = GetOrCreate(chosen.stat, pc);
        var entry = new BuffEntry(mul);
        layer.active.Add(entry);

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

    // Keyed per-enemy so buffs expire independently per instance
    private static readonly Dictionary<(EnemyController, BuffableStats), StatLayer> _enemyLayers = new();

    public static void ApplyToEnemies(BuffData chosen)
    {
        foreach (var enemy in Enemies.GetEnemyControllers())
            ApplyToEnemy(chosen, enemy);
    }

    private static void ApplyToEnemy(BuffData chosen, EnemyController enemy)
    {
        const float enemyBuffMul = 2f; // buff = enemy gets stronger (opposite of player buff)

        var key = (enemy, chosen.stat);
        if (!_enemyLayers.TryGetValue(key, out var layer))
        {
            layer = new StatLayer { baseValue = ReadEnemyBase(chosen.stat, enemy), baseCaptured = true };
            _enemyLayers[key] = layer;
        }

        var entry = new BuffEntry(enemyBuffMul);
        layer.active.Add(entry);
        RecalculateEnemy(chosen.stat, enemy, layer);

        TimeUtils.StartCountdown(chosen.durationSeconds, () =>
        {
            layer.active.Remove(entry);
            if (enemy == null) { _enemyLayers.Remove(key); return; }
            RecalculateEnemy(chosen.stat, enemy, layer);
        });
    }

    private static float ReadEnemyBase(BuffableStats stat, EnemyController enemy) => stat switch
    {
        BuffableStats.Health => enemy.GetMaxHealth(),
        BuffableStats.Strength => enemy.GetStrength(),
        _ => 0f
    };

    private static void RecalculateEnemy(BuffableStats stat, EnemyController enemy, StatLayer layer)
    {
        if (enemy == null) return;

        var health = enemy.GetComponent<Health>();
        if (health == null) return;

        switch (stat)
        {
            case BuffableStats.Health:
                health.SetMaxHealth(layer.baseValue * layer.Combined());
                break;
            case BuffableStats.Strength:
                enemy.SetStrength(layer.baseValue * layer.Combined());
                break;
        }
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
    public static void Let<T>(this T obj, Action<T> action) where T : class
    {
        if (obj != null) action(obj);
    }
}