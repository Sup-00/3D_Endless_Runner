using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : Booster
{
    private Moving _moving;
    private UpgradeSuperJumpBoosterUI _upgradeSuperJumpBoosterUI;

    private void Start()
    {
        ScaleBooster();
        _moving = FindObjectOfType<Moving>();
    }

    protected override void Boost()
    {
        _moving.BoostJumpForce(_upgradeSuperJumpBoosterUI.ActiveTime);
    }
}