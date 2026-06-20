#include "DungeonGameMode.h"
#include "AwfulPlayerController.h"

ADungeonGameMode::ADungeonGameMode() 
{
	PlayerControllerClass = AAwfulPlayerController::StaticClass();
}
void ADungeonGameMode::InitGame(const FString& MapName, const FString& Options, FString& ErrorMessage) 
{
	Super::InitGame(MapName, Options, ErrorMessage);
	
}