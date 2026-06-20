// Yes, this is awful
// - Martin

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/PlayerController.h"
#include "AwfulPlayerController.generated.h"

/**
 * 
 */
UCLASS()
class VERYSERIOUSPROJECT_API AAwfulPlayerController : public APlayerController
{
	GENERATED_BODY()

protected:
	int Health = 100;
	
public:
	enum HealthChangeFlag { ADD, SUB };

	void ChangeHealth(HealthChangeFlag Flag, int Value);
};
