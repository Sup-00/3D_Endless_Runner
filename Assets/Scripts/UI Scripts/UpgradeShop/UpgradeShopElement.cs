using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeShopElement : MonoBehaviour
{
    [SerializeField] protected Image[] _levelUI;
    [SerializeField] protected int[] _prices;
    [SerializeField] protected float[] _times;
    [SerializeField] protected TMP_Text _priceTXT;

    protected string SaveKeyName;
    protected float Timer;
    protected int Level;

    private PlayerInfo _playerInfo;

    private void Awake()
    {
        _playerInfo = FindObjectOfType<PlayerInfo>();
    }

    protected void ShowInfo()
    {
        if (Level == 5)
        {
            _priceTXT.text = "MAX";
        }
        else
        {
            _priceTXT.text = _prices[Level - 1].ToString();
        }

        Timer = _times[Level - 1];
        Boost();

        for (int i = 0; i < Level; i++)
        {
            _levelUI[i].color = Color.yellow;
        }
    }

    protected void SaveStats()
    {
        PlayerPrefs.SetInt(SaveKeyName, Level);
    }

    public void LoadStats()
    {
        if (PlayerPrefs.HasKey(SaveKeyName))

            Level = PlayerPrefs.GetInt(SaveKeyName);
        else
            Level = 1;

        Timer = _times[Level - 1];
        Boost();
    }

    protected abstract void Boost();

    public void BuyUpgrade()
    {
        if (Level != 5 && _playerInfo.TrySubtractMoney(_prices[Level - 1]))
        {
            Level += 1;
            SaveStats();
            ShowInfo();
        }
    }
}