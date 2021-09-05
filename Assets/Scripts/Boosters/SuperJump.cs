using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SuperJump : Booster
{
    private CharectorMoving _charectorMoving;
    private BoosterUI _boosterUI;
    private float _basicJumpForce;

    private void Start()
    {
        ScaleBooster();
        _charectorMoving = FindObjectOfType<CharectorMoving>();
        _basicJumpForce = _charectorMoving.JumpForce;
    }

    protected override void Boost()
    {
        _boosterUI = FindObjectOfType<BoosterUI>();

        if (_charectorMoving.IsBooted == false)
        {
            _charectorMoving.SetJumpBooster(_basicJumpForce * 3f, true);
            _boosterUI.ShowSuperJumpUI();
            StartCoroutine(ActiveTimer());
        }
    }

    private IEnumerator ActiveTimer()
    {
        yield return new WaitForSeconds(ActiveTime);
        _charectorMoving.SetJumpBooster(_basicJumpForce, false);
    }
}