using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplayer : Booster
{
    private Score _score;
    private UpgradeScoreBoosterUI _upgradeScoreBoosterUI;

    private void Start()
    {
        _upgradeScoreBoosterUI = FindObjectOfType<UpgradeScoreBoosterUI>();
        ScaleBooster();
        _score = FindObjectOfType<Score>();
    }

    protected override void Boost()
    {
        _score.MultiplayScore(2, _upgradeScoreBoosterUI.ActiveTime);
    }
}