#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "GenerateLevel.generated.h"

UCLASS()
class VERYSERIOUSPROJECT_API AGenerateLevel : public AActor
{
    GENERATED_BODY()

public:
    AGenerateLevel();

protected:
    virtual void BeginPlay() override;

public:
    virtual void Tick(float DeltaTime) override;

    void Generate(UWorld* World);

private:
    UPROPERTY()
    UStaticMesh* CubeMesh = nullptr;
};