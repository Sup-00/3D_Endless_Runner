using UnityEngine;

public class UpgradeMagnetUI : UpgradeShopElement
{
    [SerializeField] private CoinMagnet _coinMagnet;

    private void Start()
    {
        SaveKeyName = "MagnetUpgrade";
        LoadStats();
        ShowInfo();
    }

    protected override void Boost()
    {
        _coinMagnet.SetActiveTime(Timer);
    }
}