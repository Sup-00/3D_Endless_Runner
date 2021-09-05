using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSuperJumpBoosterUI : UpgradeShopElement
{
    public float ActiveTime => Timer;

    private void Start()
    {
        SaveKeyName = "SuperJumpUpgrade";
        LoadStats();
        ShowInfo();
    }

    protected override void Boost()
    {
    }
}
