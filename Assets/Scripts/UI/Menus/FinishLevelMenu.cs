using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevelMenu : GameMenu
{
    public static FinishLevelMenu Instance;

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
        var money = GameManager.Instance.GetCurrentLevel().amount;
        UIManager.Instance.OpenSummaryMenu(money);
    }
}