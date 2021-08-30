using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScoreBoosterUI : UpgradeShopElement
{
    public float ActiveTime => _timer;

    private void Start()
    {
        _saveKeyName = "ScoreBoosterUpgrade";
        LoadStats();
        ShowInfo();
    }

    protected override void Boost()
    {
    }
}