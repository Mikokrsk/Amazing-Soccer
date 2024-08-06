using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectingGamePositions : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private TextMeshProUGUI _selectingText;
    [SerializeField] private GameObject _selectingGamePositionsMenu;
    private List<PlayerPosition> playerPositions = new List<PlayerPosition>();
    [SerializeField] private int _selectedIndex;

    private void Start()
    {
        playerPositions = GetComponentsInChildren<PlayerPosition>().ToList();

        if (GameManager.Instance.gameMode == GameMode.Game)
        {
            SetActive(true);
        }
        else
        {
            SetActive(false);
        }
    }
    private void OnEnable()
    {
        GameManager.startPlayGame += () => SetActive(true);
        GameManager.pauseGame += () => SetActive(false);
        GameManager.unpauseGame += () => SetActive(true);
    }
    private void OnDisable()
    {
        GameManager.startPlayGame -= () => SetActive(true);
        GameManager.pauseGame -= () => SetActive(false);
        GameManager.unpauseGame -= () => SetActive(true);
    }

    private void SetActive(bool active)
    {
        _playButton.gameObject.SetActive(active);
        _selectingGamePositionsMenu.SetActive(active);
    }

    private void Update()
    {
        UpdatePlayerPositionCounts();
    }

    public void UpdatePlayerPositionCounts()
    {
        _selectedIndex = 0;

        foreach (var position in playerPositions)
        {
            if (position.GetActive())
            {
                _selectedIndex++;
            }
        }

        _selectingText.text = $"Choose tactic position : {_selectedIndex}/11";

        if (_selectedIndex == 11)
        {
            _playButton.interactable = true;
        }
        else
        {
            _playButton.interactable = false;
        }
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
        SetActive(false);
    }
}