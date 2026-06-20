#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "BuffComponent.generated.h"

UENUM(BlueprintType, meta = (Bitflags))
enum class EStats : uint8
{
    None = 0,
    Speed = 1 << 0,
    Strength = 1 << 1,
    Health = 1 << 2,
    LuckMul = 1 << 3,
    FutureStuff = 1 << 4
};
ENUM_CLASS_FLAGS(EStats)

USTRUCT(BlueprintType)
struct FBuff
{
    GENERATED_BODY()

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    FString Name;

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    EStats Stat = EStats::None;

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    bool bExpires = false;

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    float RemainingTime = 0.f;
};

USTRUCT(BlueprintType)
struct FDebuff
{
    GENERATED_BODY()

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    FString Name;

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    EStats Stat = EStats::None;

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    bool bExpires = false;

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    float RemainingTime = 0.f;
};

UCLASS(ClassGroup = (Custom), meta = (BlueprintSpawnableComponent))
class VERYSERIOUSPROJECT_API UBuffComponent : public UActorComponent
{
    GENERATED_BODY()

public:
    UBuffComponent();

    virtual void TickComponent(
        float DeltaTime,
        ELevelTick TickType,
        FActorComponentTickFunction* ThisTickFunction
    ) override;

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    TArray<FBuff> ActiveBuffs;

    UPROPERTY(EditAnywhere, BlueprintReadWrite)
    TArray<FDebuff> ActiveDebuffs;

    void ApplyBuff(const FBuff& Buff);
    void ApplyDebuff(const FDebuff& Debuff);

private:
    static bool HasFlag(EStats Value, EStats Flag);
    void UpdateBuffs(float DeltaTime);
    void UpdateDebuffs(float DeltaTime);
};