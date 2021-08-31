using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMagnetUI : UpgradeShopElement
{
    [SerializeField] private CoinMagnet _coinMagnet;

    private void Start()
    {
        _saveKeyName = "MagnetUpgrade";
        LoadStats();
        ShowInfo();
    }

    protected override void Boost()
    {
        _coinMagnet.SetActiveTime(_timer);
    }
}