using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : GameMenu
{
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _loadingBar;

    public override void EnableMenu()
    {
        base.EnableMenu();
        _loadingBar.SetActive(true);
        _playButton.SetActive(false);
    }

    public void LevelWasLoaded()
    {
        _loadingBar.SetActive(false);
        _playButton.SetActive(true);
    }
}