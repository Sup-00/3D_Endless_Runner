public class UpgradeScoreBoosterUI : UpgradeShopElement
{
    public float ActiveTime => Timer;

    private void Start()
    {
        SaveKeyName = "ScoreBoosterUpgrade";
        LoadStats();
        ShowInfo();
    }

    protected override void Boost()
    {
    }
}