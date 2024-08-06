using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Level Item")]

public class LevelItem : ScriptableObject
{
    public int amount;
    public int levelLoadIndex;
    public float roadLength;
    public float playerSpeed;
    public LevelDifficulty levelDifficulty;
    public bool isSpiralLevel;
}

public enum LevelDifficulty
{
    Tutorial,
    Easy,
    Medium,
    Hard
}