using System;
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
    GoodLuckMultiplier,
    ADDMORESTUFF
}


[CreateAssetMenu(fileName = "NewBuffData", menuName = "Data Assets/Buff Asset")]
public class BuffData : ScriptableObject
{
    [Header("Configuration")]
    public string assetName;
    public int Modifier;
    public BuffType type;
    public BuffableStats stat;

    public int durationSeconds = 60; // well no half seconds :(

    [Header("Visuals")]
    public Sprite? displayIcon; // Show a display Icon when the player recieves a debuff or buff
}