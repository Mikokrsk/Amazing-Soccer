using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _loadingBar;

    private void Awake()
    {
        _loadingBar.SetActive(true);
    }

    public void LevelWasLoaded()
    {
        _loadingBar.SetActive(false);
        _playButton.SetActive(true);
    }
}