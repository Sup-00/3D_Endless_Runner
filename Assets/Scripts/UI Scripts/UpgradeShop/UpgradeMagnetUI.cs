using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMagnetUI : UpgradeShopElement
{
    [SerializeField] private Magnet _magnet;

    private void Start()
    {
        _saveKeyName = "MagnetUpgrade";
        LoadStats();
        ShowInfo();
    }

    protected override void Boost()
    {
        _magnet.SetActiveTime(_timer);
    }
}