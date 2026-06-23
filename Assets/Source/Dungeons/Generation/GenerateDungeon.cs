using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class DungeonGenerator : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private int xExtent = 5;
    [SerializeField] private int yExtent = 5;

    [Header("Constraints")]
    [SerializeField, Min(2)] private int minChestRooms = 2;
    [SerializeField, Range(0f, 1f)] private float consoleSpawnChance = 0.75f;

    [Header("Prefabs")]
    [SerializeField] private GameObject startPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject chestPrefab;
    [SerializeField] private GameObject consolePrefab;
    [SerializeField] private GameObject bossPrefab;

    private DungeonRoom[,] _grid;

    private void Awake() => Generate();

    [ContextMenu("Regenerate")]
    public void Generate()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        _grid = new DungeonRoom[xExtent, yExtent];

        CreateRooms();
        AssignTypes();
        LinkNeighbors();
        SpawnPrefabs();
        WireDoors();
    }

    private void CreateRooms()
    {
        for (int x = 0; x < xExtent; x++)
            for (int y = 0; y < yExtent; y++)
                _grid[x, y] = new DungeonRoom
                {
                    GridPos = new Vector2Int(x, y),
                    Type = RoomType.Enemy        // default; overwritten below
                };
    }

    private void AssignTypes()
    {
        int startX = UnityEngine.Random.Range(0, xExtent);
        _grid[startX, 0].Type = RoomType.Start;

        int bossX = (startX + xExtent / 2 + UnityEngine.Random.Range(0, 2)) % xExtent;
        _grid[bossX, yExtent - 1].Type = RoomType.Boss;

        List<DungeonRoom> pool = AllRooms()
            .Where(r => r.Type == RoomType.Enemy)
            .ToList();
        Shuffle(pool);

        int idx = 0;

        if (UnityEngine.Random.value <= consoleSpawnChance)
        {
            DungeonRoom candidate = pool.FirstOrDefault(
                r => r.GridPos.y > 0 && r.GridPos.y < yExtent - 1);

            if (candidate != null)
            {
                candidate.Type = RoomType.Console;
                pool.Remove(candidate);
            }
        }

        int chestCount = UnityEngine.Random.Range(minChestRooms,
            Mathf.Max(minChestRooms + 1, pool.Count / 4 + 1));

        for (int i = 0; i < chestCount && idx < pool.Count; i++, idx++)
            pool[idx].Type = RoomType.Chest;

        // Remainder stays as RoomType.Enemy
    }

    private void LinkNeighbors()
    {
        for (int x = 0; x < xExtent; x++)
            for (int y = 0; y < yExtent; y++)
            {
                DungeonRoom r = _grid[x, y];
                r.North = TryGet(x, y + 1);
                r.South = TryGet(x, y - 1);
                r.East = TryGet(x + 1, y);
                r.West = TryGet(x - 1, y);
            }
    }

    private void SpawnPrefabs()
    {
        foreach (DungeonRoom room in AllRooms())
        {
            GameObject prefab = PrefabFor(room.Type);
            if (prefab == null) continue;

            GameObject go = Instantiate(
                prefab, room.WorldPosition, Quaternion.identity, transform);
            go.name = $"[{room.GridPos.x},{room.GridPos.y}] {room.Type}";

            if (go.TryGetComponent(out RoomController ctrl))
            {
                ctrl.Init(room);
                room.Controller = ctrl;
            }
        }
    }

    private void WireDoors()
    {
        foreach (DungeonRoom room in AllRooms())
            room.Controller?.WireDoors();
    }


    private GameObject PrefabFor(RoomType t) => t switch
    {
        RoomType.Start => startPrefab,
        RoomType.Boss => bossPrefab,
        RoomType.Chest => chestPrefab,
        RoomType.Console => consolePrefab,
        _ => enemyPrefab
    };

    private IEnumerable<DungeonRoom> AllRooms()
    {
        for (int x = 0; x < xExtent; x++)
            for (int y = 0; y < yExtent; y++)
                yield return _grid[x, y];
    }

    private DungeonRoom TryGet(int x, int y) =>
        (x >= 0 && x < xExtent && y >= 0 && y < yExtent) ? _grid[x, y] : null;

    private static void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    private void OnDrawGizmos()
    {
        if (_grid == null) return;

        Vector2 rs = DungeonGrid.RoomSize;
        Vector3 box = new Vector3(rs.x * 0.88f, rs.y * 0.88f, 0.5f);

        foreach (DungeonRoom room in AllRooms())
        {
            Gizmos.color = room.Type switch
            {
                RoomType.Start => Color.green,
                RoomType.Boss => Color.red,
                RoomType.Chest => Color.yellow,
                RoomType.Console => Color.cyan,
                _ => new Color(0.55f, 0.55f, 0.55f, 0.4f)
            };
            Gizmos.DrawWireCube(room.WorldPosition, box);

            Gizmos.color = Color.white * 0.2f;
            foreach (DungeonRoom n in room.Neighbors)
                Gizmos.DrawLine(room.WorldPosition, n.WorldPosition);
        }
    }
}