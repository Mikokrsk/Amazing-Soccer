using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playersPosition;
    [SerializeField] private List<Player> _playersPositionList;

    [field: SerializeField] public GameMode gameMode { get; private set; }

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
    }

    public void StartGame()
    {
        gameMode = GameMode.Game;
    }

}

public enum GameMode
{
    Game,
    MainMenu
}