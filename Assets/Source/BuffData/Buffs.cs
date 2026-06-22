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


        var PC = PlayerUtils.GetPlayerController();
        if (chosen.stat == BuffableStats.Speed)
        {
            var ResetValueA = PC.GetMoveSpeed();
            PC.SetMoveSpeed(ResetValueA / 2); // half it
            TimeUtils.StartCountdown(
                chosen.durationSeconds,
                () => PC.SetMoveSpeed(ResetValueA)
            );
        }
        else if (chosen.stat == BuffableStats.Health)
        {
            var ResetValueA = PC.GetMaxHealth();
            var ResetValueB = PC.GetRegenSpeed();

            PC.SetMaxHealth(ResetValueA / 2);
            PC.SetRegenSpeed(ResetValueB / 2);

            TimeUtils.StartCountdown(
                chosen.durationSeconds,
                () =>
                {
                    PC.SetMaxHealth(ResetValueA);
                    PC.SetRegenSpeed(ResetValueB);
                }
            );
        }
        else if (chosen.stat == BuffableStats.GoodLuckMultiplier)
        {
            var ResetValueA = PC.GetGoodLuckMultiplier();
            PC.SetGoodLuckMultiplier(ResetValueA / 2); // pain

            TimeUtils.StartCountdown(
                chosen.durationSeconds,
                () => PC.SetGoodLuckMultiplier(ResetValueA)
            );
        }
        // keep adding elifs
    }
}