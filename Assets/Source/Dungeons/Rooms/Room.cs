using UnityEngine;
using System.Collections.Generic;

public enum RoomType { Start, Enemy, Chest, Console, Boss }

public struct RoomBase
{
    public Transform[] ChestSpawns; // [0, inf) but not advisable
    public Transform[] EnemySpawns;
    public bool CanMove;
}

public struct ConsoleRoom
{
    public RoomBase Base;
    public Collider2D ConsoleTrigger;
}

public struct ChestRoom
{
    public Chest[] chests; // MonoBehaviour script
    public RoomBase Base;
}

public struct BossRoom
{
    public RoomBase Base;
    public Transform BossSpawnPoint;
}

public class DungeonRoom
{
    public RoomType Type;
    public Vector2Int GridPos;
    public RoomBase Base;

    // Populated for matching room types only
    public ChestRoom? ChestData;
    public ConsoleRoom? ConsoleData;
    public BossRoom? BossData;

    // Set after prefab is instantiated
    public RoomController Controller;

    // Cardinal neighbors (null = wall)
    public DungeonRoom North, South, East, West;

    public Vector3 WorldPosition =>
        new Vector3(GridPos.x * DungeonGrid.RoomSize.x,
                    GridPos.y * DungeonGrid.RoomSize.y, 0f);

    public IEnumerable<DungeonRoom> Neighbors
    {
        get
        {
            if (North != null) yield return North;
            if (South != null) yield return South;
            if (East != null) yield return East;
            if (West != null) yield return West;
        }
    }
}