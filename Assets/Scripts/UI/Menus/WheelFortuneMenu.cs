using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFortuneMenu : GameMenu
{
    [SerializeField] private WheelOfFortune _wheelOfFortune;

    public static WheelFortuneMenu Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public override void EnableMenu()
    {
        base.EnableMenu();
        _wheelOfFortune.GenerateSectors(5);
    }
}