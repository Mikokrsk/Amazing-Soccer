using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoadManager : MonoBehaviour
{
    [SerializeField] private int _mainMenuIndex;

    [SerializeField] private Image _startLoadScreen;
    [SerializeField] private float fadeDuration = 1.0f;

    public void FadeOut()
    {
        StartCoroutine(FadeToAlpha(0));
    }

    public void FadeIn()
    {
        StartCoroutine(FadeToAlpha(1));
    }

    private IEnumerator FadeToAlpha(float targetAlpha)
    {
        _startLoadScreen.enabled = true;
        Color color = _startLoadScreen.color;
        float startAlpha = color.a;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            _startLoadScreen.color = color;
            yield return null;
        }

        color.a = targetAlpha;
        _startLoadScreen.color = color;
    }

    public void GoToMainMenu()
    {
        StartCoroutine(LoadLevelWithFade(_mainMenuIndex));
    }

    public void LoadLevel(int levelID)
    {
        StartCoroutine(LoadLevelWithFade(levelID));
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevelWithFade(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadLevel(LevelItem levelShopItem)
    {
        StartCoroutine(LoadLevelWithFade(levelShopItem.levelLoadIndex));
    }

    private IEnumerator LoadLevelWithFade(int levelID)
    {
        yield return StartCoroutine(FadeToAlpha(1));
        SceneManager.LoadScene(levelID);
    }
}