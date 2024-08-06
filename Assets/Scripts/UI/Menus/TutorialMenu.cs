using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMenu : GameMenu
{
    [SerializeField] private Button _growButton;
    [SerializeField] private Button _shrinkButton;
    [SerializeField] private GameObject _hintGrowButtonPanel;
    [SerializeField] private GameObject _hintShrinkButtonPanel;
    // [SerializeField] private GameObject _hintSettingsButtonPanel;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Player _player;
    [SerializeField] private float _ActivateHintGrowDelay;
    [SerializeField] private float _ActivateHintShrinkDelay;


    public override void EnableMenu()
    {
        base.EnableMenu();
        _shrinkButton.interactable = false;
        _growButton.interactable = false;
        StartCoroutine(ActivateHintGrowButtonPanelWithDelay());
    }

    private IEnumerator ActivateHintGrowButtonPanelWithDelay()
    {
        yield return new WaitForSeconds(_ActivateHintGrowDelay);
        ActivateHintGrowButtonPanel();
    }

    public void ActivateHintGrowButtonPanel()
    {
        _growButton.interactable = true;
        _hintGrowButtonPanel.SetActive(true);
        //   _player.StopPlayerAction();
    }

    public void GrowButtonPressed()
    {
        _growButton.interactable = false;
        _hintGrowButtonPanel.SetActive(false);
        //    _player.RestorePlayerAction();
        StartCoroutine(ActivateHintShrinkButtonPanelWithDelay());
    }

    private IEnumerator ActivateHintShrinkButtonPanelWithDelay()
    {
        yield return new WaitForSeconds(_ActivateHintShrinkDelay);
        ActivateHintShrinkButtonPanel();
    }

    private void ActivateHintShrinkButtonPanel()
    {
        _shrinkButton.interactable = true;
        _hintShrinkButtonPanel.SetActive(true);
        //   _player.StopPlayerAction();
    }

    public void ShrinkButtonPressed()
    {
        _shrinkButton.interactable = false;
        _hintShrinkButtonPanel.SetActive(false);
        //  _player.RestorePlayerAction();
    }
}