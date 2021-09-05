public class CoinMagnet : Booster
{
    private MagnetCollider _magnetCollider;

    private void Start()
    {
        ScaleBooster();
        _magnetCollider = FindObjectOfType<MagnetCollider>();
    }

    protected override void Boost()
    {
        _magnetCollider.ActiveMagnet(ActiveTime);
    }
}