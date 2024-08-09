using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private FinishLevelMenu _finishLevelMenu;
    // [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private WheelFortuneMenu _wheelFortuneMenu;
    [SerializeField] private SettingsMenu _settingsMenu;
    [SerializeField] private SummaryMenu _summaryMenu;
    [SerializeField] private ShopMenu _shopMenu;
    [SerializeField] private ShopMenu _levelSelectMenu;
    [SerializeField] private GameObject _shopMenus;
    // [SerializeField] private ControlButtonsMenu _controlButtonsMenu;
    [SerializeField] private TutorialMenu _tutorialMenu;
    [SerializeField] private WarningMessageMenu _warningMessageMenu;
    [SerializeField] private GameObject _GameUI;

    [SerializeField] private LoadScreen _loadScreen;

    [SerializeField] private GameManager _gameManager;

    public static UIManager Instance;

    private void OnEnable()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        var level = _gameManager.GetCurrentLevel();
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_gameManager.GetCurrentGameMode() == GameMode.MainMenu)
        {
            OpenLoadScreenMenu();
        }
        else
        {
            CloseLoadScreenMenu();
        }
        /*
        if (level.name == "Tutorial Level")
        {
            _tutorialMenu.EnableMenu();
        }*/
    }

    public void OpenShopMenus()
    {
        _shopMenus.SetActive(true);
    }
    public void CloseShopMenus()
    {
        _shopMenus.SetActive(false);
    }

    public void OpenGameMenuUI()
    {
        CloseAllMenus();

        if (GameManager.Instance.GetCurrentLevel().levelDifficulty == LevelDifficulty.Tutorial)
        {
            OpenTutorialMenu();
        }
        else
        {
            //    OpenControlButtonsMenu();
        }
    }
    public void OpenMainMenuUI()
    {
        CloseAllMenus();
        if (GameManager.Instance.GetCurrentGameMode() == GameMode.MainMenu)
        {
            OpenShopMenu();
            OpenLevelSelectMenu();
            _settingsMenu.UpdateGameMode();
        }
    }

    public void OpenSettingsMenu()
    {
        OpenMenu(_settingsMenu);
    }
    public void CloseSettingsMenu()
    {
        CloseMenu(_settingsMenu);
    }

    public void OpenWheelFortuneMenu()
    {
        OpenMenu(_wheelFortuneMenu);
    }
    public void CloseWheelFortuneMenu()
    {
        CloseMenu(_wheelFortuneMenu);
    }

    public void OpenFinishLevelMenu()
    {
        OpenMenu(_finishLevelMenu);
    }
    public void CloseFinishLevelMenu()
    {
        CloseMenu(_finishLevelMenu);
    }

    public void OpenSummaryMenu(int amount)
    {
        _summaryMenu.SetSummary(amount);
        _summaryMenu.EnableMenu();
    }
    public void CloseSummaryMenu()
    {
        CloseMenu(_summaryMenu);
    }

    public void OpenShopMenu()
    {
        OpenMenu(_shopMenu);
        CloseMenu(_levelSelectMenu);
    }
    public void CloseShopMenu()
    {
        OpenMenu(_levelSelectMenu);
        CloseMenu(_shopMenu);
    }

    public void OpenLevelSelectMenu()
    {
        OpenMenu(_levelSelectMenu);
        CloseMenu(_shopMenu);
    }
    public void CloseLevelSelectMenu()
    {
        OpenMenu(_shopMenu);
        CloseMenu(_levelSelectMenu);
    }

    public void OpenTutorialMenu()
    {
        OpenMenu(_tutorialMenu);
    }
    public void CloseTutorialMenu()
    {
        CloseMenu(_tutorialMenu);
    }

    public void OpenLoadScreenMenu()
    {
        OpenMenu(_loadScreen);
    }
    public void CloseLoadScreenMenu()
    {
        CloseMenu(_loadScreen);
    }

    public void OpenWarningMessageMenu()
    {
        OpenMenu(_warningMessageMenu);
    }
    public void CloseWarningMessageMenu()
    {
        CloseMenu(_warningMessageMenu);
    }

    private void OpenMenu(GameMenu gameMenu)
    {
        gameMenu.EnableMenu();
    }
    private void CloseMenu(GameMenu gameMenu)
    {
        // CloseAllMenus();
        gameMenu.DisableMenu();
    }

    public void CloseAllMenus()
    {
        CloseSettingsMenu();
        CloseWheelFortuneMenu();
        CloseFinishLevelMenu();
        // CloseControlButtonsMenu();
        CloseLevelSelectMenu();
        CloseTutorialMenu();
        CloseShopMenu();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GoToHome()
    {
        CloseAllMenus();
        //  _levelLoadManager.GoToMainMenu();
    }

    public void RestartLevel()
    {
        CloseAllMenus();
        //  _gameManager.RestartLevel();
    }
}