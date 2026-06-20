#include "BuffComponent.h"

UBuffComponent::UBuffComponent()
{
    PrimaryComponentTick.bCanEverTick = true;
}

bool UBuffComponent::HasFlag(EStats Value, EStats Flag)
{
    return EnumHasAnyFlags(Value, Flag);
}

void UBuffComponent::ApplyBuff(const FBuff& Buff)
{
    ActiveBuffs.Add(Buff);

    if (HasFlag(Buff.Stat, EStats::Speed))
    {
        // Increase speed
    }

    if (HasFlag(Buff.Stat, EStats::Strength))
    {
        // Increase strength
    }

    if (HasFlag(Buff.Stat, EStats::Health))
    {
        // Increase health
    }

    if (HasFlag(Buff.Stat, EStats::LuckMul))
    {
        // Increase luck
    }
}

void UBuffComponent::ApplyDebuff(const FDebuff& Debuff)
{
    ActiveDebuffs.Add(Debuff);

    if (HasFlag(Debuff.Stat, EStats::Speed))
    {
        // Reduce speed
    }

    if (HasFlag(Debuff.Stat, EStats::Strength))
    {
        // Reduce strength
    }

    if (HasFlag(Debuff.Stat, EStats::Health))
    {
        // Reduce health
    }

    if (HasFlag(Debuff.Stat, EStats::LuckMul))
    {
        // Reduce luck
    }
}

void UBuffComponent::UpdateBuffs(float DeltaTime)
{
    for (int32 i = ActiveBuffs.Num() - 1; i >= 0; --i)
    {
        FBuff& Buff = ActiveBuffs[i];

        if (!Buff.bExpires)
            continue;

        Buff.RemainingTime -= DeltaTime;

        if (Buff.RemainingTime <= 0.f)
        {
            // Undo buff effect here

            ActiveBuffs.RemoveAt(i);
        }
    }
}

void UBuffComponent::UpdateDebuffs(float DeltaTime)
{
    for (int32 i = ActiveDebuffs.Num() - 1; i >= 0; --i)
    {
        FDebuff& Debuff = ActiveDebuffs[i];

        if (!Debuff.bExpires)
            continue;

        Debuff.RemainingTime -= DeltaTime;

        if (Debuff.RemainingTime <= 0.f)
        {
            // Undo debuff effect here

            ActiveDebuffs.RemoveAt(i);
        }
    }
}

void UBuffComponent::TickComponent(
    float DeltaTime,
    ELevelTick TickType,
    FActorComponentTickFunction* ThisTickFunction)
{
    Super::TickComponent(
        DeltaTime,
        TickType,
        ThisTickFunction);

    UpdateBuffs(DeltaTime);
    UpdateDebuffs(DeltaTime);
}