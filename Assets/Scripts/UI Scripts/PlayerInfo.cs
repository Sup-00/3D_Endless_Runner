using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreUI;
    [SerializeField] private TMP_Text _mainMenuPlayerMoneyUI;
    [SerializeField] private TMP_Text _shopPlayerMoneyUI;

    private float _playerMoney;
    private float _bestScore;
    private const string BEST_SCORE = "BestScore";
    private const string PLAYER_MONEY = "PlayerMoney";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(BEST_SCORE))
            _bestScore = PlayerPrefs.GetFloat(BEST_SCORE);
        else
            _bestScore = 0f;

        if (PlayerPrefs.HasKey(PLAYER_MONEY))
            _playerMoney = PlayerPrefs.GetFloat(PLAYER_MONEY);
        else
            _playerMoney = 0f;

        _bestScoreUI.text = _bestScore.ToString("#");
        _mainMenuPlayerMoneyUI.text = _shopPlayerMoneyUI.text = _playerMoney.ToString();
    }

    public void SetPlayerStats(float money, float score)
    {
        if (score > _bestScore)
        {
            _bestScore = score;
            _bestScoreUI.text = _bestScore.ToString("#");
        }

        _playerMoney += money;
        RenredMoneyUI();
        SavePlayerStats();
    }

    private void RenredMoneyUI()
    {
        _mainMenuPlayerMoneyUI.text = _shopPlayerMoneyUI.text = _playerMoney.ToString();
    }

    private void SavePlayerStats()
    {
        PlayerPrefs.SetFloat(BEST_SCORE, _bestScore);
        PlayerPrefs.SetFloat(PLAYER_MONEY, _playerMoney);
    }

    public bool TrySubtractMoney(int count)
    {
        if (_playerMoney >= count)
        {
            _playerMoney -= count;
            RenredMoneyUI();
            SavePlayerStats();
            return true;
        }
        else
        {
            return false;
        }
    }
}