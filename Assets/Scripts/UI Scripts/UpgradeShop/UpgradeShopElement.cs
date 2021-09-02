using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeShopElement : MonoBehaviour
{
    [SerializeField] protected Image[] _levelUI;
    [SerializeField] protected int[] _prices;
    [SerializeField] protected float[] _times;
    [SerializeField] protected TMP_Text _priceTXT;

    protected string _saveKeyName;
    protected float _timer;
    protected int _level;

    private PlayerInfo _playerInfo;

    private void Awake()
    {
        _playerInfo = FindObjectOfType<PlayerInfo>();
    }

    protected void ShowInfo()
    {
        if (_level == 5)
        {
            _priceTXT.text = "MAX";
        }
        else
        {
            _priceTXT.text = _prices[_level - 1].ToString();
        }

        _timer = _times[_level - 1];
        Boost();

        for (int i = 0; i < _level; i++)
        {
            _levelUI[i].color = Color.yellow;
        }
    }

    protected void SaveStats()
    {
        PlayerPrefs.SetInt(_saveKeyName, _level);
    }

    public void LoadStats()
    {
        if (PlayerPrefs.HasKey(_saveKeyName))

            _level = PlayerPrefs.GetInt(_saveKeyName);
        else
            _level = 1;

        _timer = _times[_level - 1];
        Boost();
    }

    protected abstract void Boost();

    public void BuyUpgrade()
    {
        if (_level != 5 && _playerInfo.TrySubtractMoney(_prices[_level - 1]))
        {
            _level += 1;
            SaveStats();
            ShowInfo();
        }
    }
}