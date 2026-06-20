#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "BuffComponent.h"


#include "BuffData.generated.h"

UCLASS(BlueprintType)
class UBuffData : public UDataAsset
{
    GENERATED_BODY()

public:
    UPROPERTY(EditAnywhere)
    FString Name;

    UPROPERTY(EditAnywhere)
    EStats Stat;

    UPROPERTY(EditAnywhere)
    float Duration;
};