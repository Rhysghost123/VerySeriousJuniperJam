using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class DungeonGrid
{
    public static Vector2 RoomSize; // meters 
    public int X_Extent;
    public int Y_Extent;
    public List<Transform> Positions;

    public DungeonGrid()
    {
        RoomSize = new Vector2(20, 20);
        X_Extent = 5; // rooms wide
        Y_Extent = 5; // rooms long
        Positions = new List<Transform>(X_Extent * Y_Extent);
    }
}