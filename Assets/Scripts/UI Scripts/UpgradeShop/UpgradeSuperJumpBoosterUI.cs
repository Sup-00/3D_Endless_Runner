using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSuperJumpBoosterUI : UpgradeShopElement
{
    public float ActiveTime => _timer;

    private void Start()
    {
        _saveKeyName = "SuperJumpUpgrade";
        LoadStats();
        ShowInfo();
    }

    protected override void Boost()
    {
    }
}
