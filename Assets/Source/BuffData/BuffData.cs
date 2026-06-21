using UnityEngine;

public enum BuffType
{
    Buff,
    Debuff
}

public enum BuffableStats
{
    Speed,
    Strength,
    Health,
    LuckMultiplier,
    ADDMORESTUFF
}


[CreateAssetMenu(fileName = "NewBuffData", menuName = "Data Assets/Buff Asset")]
public class BuffData : ScriptableObject
{
    [Header("Configuration")]
    public string assetName;
    public int baseValue;
    public BuffType type;
    public BuffableStats stat;

    public float durationSeconds = 60;

    [Header("Visuals")]
    public Sprite displayIcon; // Show a display Icon when the player recieves a debuff or buff
}