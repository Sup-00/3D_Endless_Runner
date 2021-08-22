using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreUI;
    [SerializeField] private TMP_Text _mainMenuPlayerMoneyUI;
    [SerializeField] private TMP_Text _shopPlayerMoneyUI;

    private float _playerMoney;
    private float _bestScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("BestScore"))
            _bestScore = PlayerPrefs.GetFloat("BestScore");
        else
            _bestScore = 0f;

        if (PlayerPrefs.HasKey("PlayerMoney"))
            _playerMoney = PlayerPrefs.GetFloat("PlayerMoney");
        else
            _playerMoney = 0f;

        _bestScoreUI.text = _bestScore.ToString("#");
        _mainMenuPlayerMoneyUI.text = _shopPlayerMoneyUI.text = _playerMoney.ToString();
    }

    public void SetPlayerStats(float money, float score)
    {
        if (score > _bestScore)
        {
            _bestScore = score;
            _bestScoreUI.text = _bestScore.ToString("#");
        }

        _playerMoney += money;
        _mainMenuPlayerMoneyUI.text = _shopPlayerMoneyUI.text = _playerMoney.ToString();

        SavePlayerStats();
    }

    private void SavePlayerStats()
    {
        PlayerPrefs.SetFloat("BestScore", _bestScore);
        PlayerPrefs.SetFloat("PlayerMoney", _playerMoney);
    }
}