using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : GameMenu
{
    private const string OPEN_SHOP_MENU_TRIGGER_NAME = "Open";
    private const string CLOSE_SHOP_MENU_TRIGGER_NAME = "Close";
    [SerializeField] private Animator _animator;

    [SerializeField] private bool _isMenuOpened;

    public override void Start()
    {
        base.Start();
        _isMenuOpened = false;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            EnableMenu();
        }
        else
        {
            DisableMenu();
        }
    }

    public void TogleMenu()
    {
        if (_isMenuOpened)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    public override void EnableMenu()
    {
        base.EnableMenu();
        OpenMenu();
    }

    private void OpenMenu()
    {
        //  _animator.SetTrigger(OPEN_SHOP_MENU_TRIGGER_NAME);
        _isMenuOpened = true;
    }

    public override void DisableMenu()
    {
        base.DisableMenu();
        CloseMenu();
    }

    private void CloseMenu()
    {
        //  _animator.SetTrigger(CLOSE_SHOP_MENU_TRIGGER_NAME);
        _isMenuOpened = false;
    }
}