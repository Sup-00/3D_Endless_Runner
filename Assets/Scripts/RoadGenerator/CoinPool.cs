using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private int _poolStartSize;
    [SerializeField] private Coin _coinPrefab;

    [SerializeField] private List<Coin> _coinPool;

    private void Awake()
    {
        _coinPool = new List<Coin>();

        for (int i = 0; i < _poolStartSize; i++)
        {
            InitCoin();
        }
    }

    private void InitCoin()
    {
        Coin coin = Instantiate(_coinPrefab, transform);
        coin.gameObject.SetActive(false);
        _coinPool.Add(coin);
    }

    public Coin GetCoin()
    {
        for (int i = 0; i < _coinPool.Count; i++)
        {
            if (_coinPool[i].gameObject.activeSelf == false)
                return _coinPool[i];
        }

        return null;
    }
}