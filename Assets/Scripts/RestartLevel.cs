using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;

    private Score _score;
    private CoinCollecter _coinCollecter;
    private PlayerInfo _playerInfo;

    private void Start()
    {
        _coinCollecter = FindObjectOfType<CoinCollecter>();
        _playerInfo = GetComponent<PlayerInfo>();
        _score = FindObjectOfType<Score>();
    }

    public void Restart()
    {
        _playerInfo.SetPlayerStats(_coinCollecter.PlayerCoins, _score.PlayerScore);
        SceneManager.LoadScene(_scene.name);
    }
}