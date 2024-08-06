using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : GameMenu
{
    public static GameOverMenu Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}