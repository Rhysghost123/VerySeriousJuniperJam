using UnityEngine;

public enum DoorState { Wall, Locked, Open }

public class DoorController : MonoBehaviour
{
    [Header("Direction this door faces")]
    public Direction Direction;

    [Header("Child visuals — assign in prefab")]
    [SerializeField] private GameObject wallVisual;   // solid wall tile/sprite
    [SerializeField] private GameObject doorVisual;   // door frame sprite
    [SerializeField] private GameObject openVisual;   // open archway / no wall

    [Header("Trigger — must cover the doorway opening")]
    [SerializeField] private Collider2D passTrigger;  // IsTrigger = true

    public DungeonRoom LeadsTo { get; private set; }
    public RoomController OwnerRoom { get; private set; }

    public void Init(RoomController owner, DungeonRoom neighbor)
    {
        OwnerRoom = owner;
        LeadsTo = neighbor;
        SetState(neighbor == null ? DoorState.Wall : DoorState.Locked);
    }

    public void SetState(DoorState state)
    {
        bool isWall = state == DoorState.Wall;
        bool isOpen = state == DoorState.Open;

        if (wallVisual) wallVisual.SetActive(isWall);
        if (doorVisual) doorVisual.SetActive(!isWall && !isOpen);
        if (openVisual) openVisual.SetActive(isOpen);

        // Only let the player cross when open
        if (passTrigger) passTrigger.enabled = isOpen;
    }

    // Called by RoomController.SetCleared()
    public void Unlock() => SetState(DoorState.Open);
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (LeadsTo?.Controller == null) return;

        Direction entry = Direction.Opposite();
        Vector3 spawnPoint = LeadsTo.Controller.GetEntryPoint(entry);

        other.transform.position = spawnPoint;
    }
}