using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplayer : Booster
{
    private Score _score;
    private float _activeTime = 3;
    
    private void Start()
    {
        ScaleBooster();
        _score = FindObjectOfType<Score>();
    }

    protected override void Boost()
    {
        _score.MultiplayScore(2);
        _score.StartTimer(_activeTime);
    }
    
}
