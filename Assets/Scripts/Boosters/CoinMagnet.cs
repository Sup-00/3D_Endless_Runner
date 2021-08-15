using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : Booster
{
    private Magnet _magnet;
    
    private void Start()
    {
        ScaleBooster();
        _magnet = FindObjectOfType<Magnet>();
        _activeTime = 30;
    }

    protected override void Boost()
    {
        _magnet.ActiveMagnet(_activeTime);
    }
}
