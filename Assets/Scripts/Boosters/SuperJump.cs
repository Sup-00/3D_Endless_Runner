using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : Booster
{
    private Moving _moving;
    
    private void Start()
    {
        ScaleBooster();
        _moving = FindObjectOfType<Moving>();
        _activeTime = 30;
    }

    protected override void Boost()
    {
        _moving.BoostJumpForce(_activeTime);
    }
}
