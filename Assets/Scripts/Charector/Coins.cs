using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    [SerializeField] private int _coin;

    public int PlayerCoins => _coin;

    private void Start()
    {
        _coin = 0;
        RenderMoneyText();
    }

    public void AddCoin(int count)
    {
        _coin += count;
        RenderMoneyText();
    }

    public void SubtractCoin(int count)
    {
        if (_coin >= count)
        {
            _coin -= count;
            RenderMoneyText();
        }
    }

    private void RenderMoneyText()
    {
        _moneyText.text = (_coin).ToString();
    }
}