using TMPro;
using UnityEngine;

public class CoinCollecter : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    [SerializeField] private int _coin;

    public int PlayerCoins => _coin;

    private void Start()
    {
        _coin = 0;
        RenderMoneyText();
    }

    public void AddCoin()
    {
        _coin++;
        RenderMoneyText();
    }

    private void RenderMoneyText()
    {
        _moneyText.text = (_coin).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>())
        {
            AddCoin();
            other.transform.gameObject.SetActive(false);
            other.GetComponent<Coin>().ActiveBooster(false);
        }
    }
}