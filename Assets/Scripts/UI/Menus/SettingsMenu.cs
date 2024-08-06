using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : GameMenu
{
    public static SettingsMenu Instance;

    [SerializeField] private GameObject _goToHomeButton;
    [SerializeField] private GameObject _restartLevelButton;

    public override void Start()
    {
        base.Start();
        UpdateGameMode();
    }

    public override void EnableMenu()
    {
        base.EnableMenu();
        UpdateGameMode();
    }

    public void UpdateGameMode()
    {
        if (GameManager.Instance.GetCurrentGameMode() == GameMode.MainMenu)
        {
            _goToHomeButton.SetActive(false);
            _restartLevelButton.SetActive(false);
        }
        else
        {
            _goToHomeButton.SetActive(true);
            _restartLevelButton.SetActive(true);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}