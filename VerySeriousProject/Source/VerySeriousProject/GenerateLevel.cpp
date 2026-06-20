#include "GenerateLevel.h"

#include "Engine/World.h"
#include "Engine/StaticMeshActor.h"
#include "UObject/ConstructorHelpers.h"

AGenerateLevel::AGenerateLevel()
{
    PrimaryActorTick.bCanEverTick = true;

    static ConstructorHelpers::FObjectFinder<UStaticMesh>
        MeshFinder(TEXT("/Engine/BasicShapes/Cube.Cube"));

    if (MeshFinder.Succeeded())
    {
        CubeMesh = MeshFinder.Object;
    }
}

void AGenerateLevel::BeginPlay()
{
    Super::BeginPlay();
    Generate(GetWorld());
}

void AGenerateLevel::Tick(float DeltaTime)
{
    Super::Tick(DeltaTime);
}

void AGenerateLevel::Generate(UWorld* World)
{
    if (!World)
    {
        return;
    }

    constexpr int32 GridSize = 10;
    constexpr float Spacing = 2000.0f; // 2000cm = 20m
    constexpr float ConnectionSpace = 10;

    for (int32 X = 0; X < GridSize; X++)
    {
        for (int32 Y = 0; Y < GridSize; Y++)
        {
            FVector Location(
                X * Spacing,
                Y * Spacing,
                100.0f);

            AStaticMeshActor* Cube =
                World->SpawnActor<AStaticMeshActor>(
                    AStaticMeshActor::StaticClass(),
                    Location,
                    FRotator::ZeroRotator);

            if (Cube && CubeMesh)
            {
                Cube->GetStaticMeshComponent()->SetStaticMesh(CubeMesh);
            }
        }
    }
}