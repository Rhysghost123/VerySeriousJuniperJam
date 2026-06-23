using UnityEngine;
public enum Direction { North, South, East, West }

public static class DirectionExtensions
{
    public static Direction Opposite(this Direction d) => d switch
    {
        Direction.North => Direction.South,
        Direction.South => Direction.North,
        Direction.East => Direction.West,
        Direction.West => Direction.East,
        _ => d
    };

    public static Vector2 ToVector(this Direction d) => d switch
    {
        Direction.North => Vector2.up,
        Direction.South => Vector2.down,
        Direction.East => Vector2.right,
        Direction.West => Vector2.left,
        _ => Vector2.zero
    };
}