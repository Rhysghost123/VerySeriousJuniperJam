using UnityEngine;

[DisallowMultipleComponent]
public class RoomController : MonoBehaviour
{
    public DungeonRoom Room { get; private set; }
    public bool IsCleared { get; private set; }

    [Header("Shared spawn points")]
    [SerializeField] private Transform[] chestSpawnPoints;
    [SerializeField] private Transform[] enemySpawnPoints;

    [Header("Type-specific")]
    [SerializeField] private Chest[] chests;
    [SerializeField] private Collider2D consoleTrigger;
    [SerializeField] private Transform bossSpawnPoint;
    [Header("Doors (one per cardinal direction)")]
    [SerializeField] private DoorController northDoor;
    [SerializeField] private DoorController southDoor;
    [SerializeField] private DoorController eastDoor;
    [SerializeField] private DoorController westDoor;

    private const float EntryInset = 1.5f;

    public void Init(DungeonRoom room)
    {
        Room = room;

        room.Base = new RoomBase
        {
            ChestSpawns = chestSpawnPoints,
            EnemySpawns = enemySpawnPoints,
            CanMove = room.Type != RoomType.Enemy
        };

        switch (room.Type)
        {
            case RoomType.Chest:
                room.ChestData = new ChestRoom { chests = chests, Base = room.Base };
                foreach (Chest c in chests)
                    c?.SetLoot(Loot.RandomEnum<LootType>());
                break;

            case RoomType.Console:
                room.ConsoleData = new ConsoleRoom
                {
                    ConsoleTrigger = consoleTrigger,
                    Base = room.Base
                };
                break;

            case RoomType.Boss:
                room.BossData = new BossRoom
                {
                    Base = room.Base,
                    BossSpawnPoint = bossSpawnPoint
                };
                break;
        }
    }
    public void WireDoors()
    {
        northDoor?.Init(this, Room.North);
        southDoor?.Init(this, Room.South);
        eastDoor?.Init(this, Room.East);
        westDoor?.Init(this, Room.West);

        if (Room.Type is RoomType.Start or RoomType.Chest)
            SetCleared();
    }

    public Vector3 GetEntryPoint(Direction from)
    {
        Vector2 half = DungeonGrid.RoomSize * 0.5f;
        Vector2 offset = from.ToVector();           // e.g. North → (0, 1)

        Vector2 local = new Vector2(
            offset.x * (half.x - EntryInset),
            offset.y * (half.y - EntryInset));

        return transform.position + (Vector3)local;
    }


    public void OnEnemyDefeated()
    {
        // TODO: decrement counter; call SetCleared() when zero
    }

    public void SetCleared()
    {
        if (IsCleared) return;
        IsCleared = true;
        Room.Base.CanMove = true;

        // Unlock every door that has a neighbor
        northDoor?.Unlock();
        southDoor?.Unlock();
        eastDoor?.Unlock();
        westDoor?.Unlock();

        Debug.Log($"Room [{Room.GridPos}] {Room.Type} cleared — doors opened.");
    }

    private DoorController DoorFor(Direction d) => d switch
    {
        Direction.North => northDoor,
        Direction.South => southDoor,
        Direction.East => eastDoor,
        Direction.West => westDoor,
        _ => null
    };
}