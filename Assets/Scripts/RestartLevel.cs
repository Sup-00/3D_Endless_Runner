using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;

    private Score _score;
    private Coins _coins;
    private PlayerInfo _playerInfo;

    private void Start()
    {
        _coins = FindObjectOfType<Coins>();
        _playerInfo = GetComponent<PlayerInfo>();
        _score = FindObjectOfType<Score>();
    }

    public void Restart()
    {
        _playerInfo.SetPlayerStats(_coins.PlayerCoins, _score.PlayerScore);
        SceneManager.LoadScene(_scene.name);
    }
}