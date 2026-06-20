#pragma once

#include "CoreMinimal.h"
#include "GameFramework/HUD.h"
#include "TranslateRoomsHUD.generated.h"

/**
 * 
 */
UCLASS()
class VERYSERIOUSPROJECT_API ATranslateRoomsHUD : public AHUD
{
	GENERATED_BODY()
public:

	enum TranslationDirection {
		NORTH,
		EAST,
		SOUTH,
		WEST
	};

	enum class AvailableRoomTranslationsDirections { // Update for each ROOM so the rooms do not move into eachother (that would be bad)
		NORTH = 0,
		EAST = 1 << 0,
		SOUTH = 1 << 1,
		WEST = 1 << 2
	};

	void Translate(AvailableRoomTranslationsDirections availableDirs, TranslationDirection dir);

	void Tick(float DeltaTime) override;
};
