using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playersPosition;
    [SerializeField] private List<Player> _playersPositionList;
    [SerializeField] private LevelItem _currentLevel;
    [SerializeField] private LevelLoadManager _levelLoadManager;
    [SerializeField] private GameMode _gameMode;

    public static event Action goToMainMenu;
    public static event Action startSelectingGamePositionMenu;
    public static event Action stopSelectingGamePositionMenu;
    public static event Action startPlayGame;
    public static event Action pauseGame;
    public static event Action unpauseGame;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _gameMode = GameMode.MainMenu;
        }
        else
        {
            _gameMode = GameMode.Game;
        }

        _levelLoadManager.FadeOut();
    }

    public void StartGame()
    {
        _gameMode = GameMode.Game;
        startPlayGame?.Invoke();
    }

    public void PauseGame()
    {
        _gameMode = GameMode.Pause;
        pauseGame?.Invoke();
    }

    public void UnpauseGame()
    {
        _gameMode = GameMode.Game;
        unpauseGame?.Invoke();
    }

    public GameMode GetCurrentGameMode()
    {
        return _gameMode;
    }

    public LevelItem GetCurrentLevel()
    {
        return _currentLevel;
    }

}

public enum GameMode
{
    Game,
    MainMenu,
    Pause
}