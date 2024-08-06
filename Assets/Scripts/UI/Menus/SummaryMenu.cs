using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SummaryMenu : GameMenu
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI _summaryText;

    private const string START_COIN_CONFETTI_TRIGGER_NAME = "StartCoinConfetti";

    public override void Start()
    {
        var money = GameManager.Instance.GetCurrentLevel().amount;
        _summaryText.text = money.ToString();
    }


    private void StartConfetti()
    {
        _animator.SetTrigger(START_COIN_CONFETTI_TRIGGER_NAME);
    }

    public override void EnableMenu()
    {
        base.EnableMenu();
        StartConfetti();
    }

    public void SetSummary(int amount)
    {
        if (amount <= 0)
        {
            amount = 1;
        }

        Wallet.Instance.AddMoney(amount);
        _summaryText.text = amount.ToString();
    }
}