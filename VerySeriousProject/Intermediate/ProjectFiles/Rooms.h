#pragma once
#pragma once

enum class AvailableRoomTranslationDirections {
	NORTH = 0,
	EAST = 1 << 1,
	SOUTH = 1 << 2,
	WEST = 1 << 3
};

enum SelectedRoomTranslationDirection
{
	NORTH,
	EAST,
	SOUTH,
	WEST
};

enum RoomType {
	BOSS,
	CHEST,
	ENEMY_SPAWN,
	CONSOLE
};

struct Room
{
public:
	char* ID;
	bool CanMove;

	RoomType Type;
	AvailableRoomTranslationDirections AvailableTranslationDirections;
};