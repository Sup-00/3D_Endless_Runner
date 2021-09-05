public class SuperJump : Booster
{
    private CharectorMoving _charectorMoving;
    private UpgradeSuperJumpBoosterUI _upgradeSuperJumpBoosterUI;

    private void Start()
    {
        ScaleBooster();
        _upgradeSuperJumpBoosterUI = FindObjectOfType<UpgradeSuperJumpBoosterUI>();
        _charectorMoving = FindObjectOfType<CharectorMoving>();
    }

    protected override void Boost()
    {
        _charectorMoving.BoostJumpForce(_upgradeSuperJumpBoosterUI.ActiveTime);
    }
}