public class ScoreMultiplayer : Booster
{
    private Score _score;
    private UpgradeScoreBoosterUI _upgradeScoreBoosterUI;

    private void Start()
    {
        _score = FindObjectOfType<Score>();
        _upgradeScoreBoosterUI = FindObjectOfType<UpgradeScoreBoosterUI>();
        _upgradeScoreBoosterUI.LoadStats();
        ScaleBooster();
    }

    protected override void Boost()
    {
        _score.MultiplayScore(2, _upgradeScoreBoosterUI.ActiveTime);
    }
}