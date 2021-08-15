using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Coins _coins;
    private int _coinCount = 1;
    private Moving _moving;
    private bool _isBoosted = false;

    private void Update()
    {
        if (_isBoosted)
            transform.DOMove(_moving.transform.position, 0.4f);
    }

    private void Start()
    {
        _coins = FindObjectOfType<Coins>();
        _moving = FindObjectOfType<Moving>();
        RotateCoin();
    }

    private void RotateCoin()
    {
        Tween tween = transform.DORotate(new Vector3(0f, 350f, 0f), 2, RotateMode.FastBeyond360);
        tween.SetLoops(-1, LoopType.Restart);
        tween.SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Moving>())
        {
            _coins.AddCoin(_coinCount);
            transform.gameObject.SetActive(false);
            _isBoosted = false;
        }
    }

    public void ActiveBooster(bool state)
    {
        _isBoosted = state;
    }
}