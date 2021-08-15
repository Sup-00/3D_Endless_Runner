using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplayer : Booster
{
    private Score _score;

    private void Start()
    {
        ScaleBooster();
        _activeTime = 30;
        _score = FindObjectOfType<Score>();
    }

    protected override void Boost()
    {
        _score.MultiplayScore(2, _activeTime);
    }
    
}
