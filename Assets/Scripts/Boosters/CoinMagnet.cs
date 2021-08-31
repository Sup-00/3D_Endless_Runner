using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : Booster
{
    private MagnetCollider _magnetCollider;
    private UpgradeMagnetUI _upgradeMagnetUI;

    private void Start()
    {
        _upgradeMagnetUI = FindObjectOfType<UpgradeMagnetUI>();
        ScaleBooster();
        _magnetCollider = FindObjectOfType<MagnetCollider>();
    }

    protected override void Boost()
    {
        _magnetCollider.ActiveMagnet(_activeTime);
    }
}