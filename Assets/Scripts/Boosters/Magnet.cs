using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Booster
{
    private bool _isBoosted = false;
    private Moving _moving;
    private BoosterUI _boosterUI;

    private void Start()
    {
        ScaleBooster();
        _boosterUI = FindObjectOfType<BoosterUI>();
        _moving = FindObjectOfType<Moving>();
    }

    private void Update()
    {
        transform.position = _moving.transform.position;
    }

    public void ActiveMagnet(float activeTime)
    {
        if (_isBoosted == false)
        {
            transform.GetComponent<BoxCollider>().enabled = true;
            _isBoosted = true;
            _boosterUI.ShowMagnetUI(activeTime);
            StartCoroutine(ActiveTimer(activeTime));
        }
    }

    private IEnumerator ActiveTimer(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        _isBoosted = false;
        transform.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isBoosted)
        {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
            {
                coin.ActiveBooster(true);
            }
        }
    }

    protected override void Boost()
    {
        ActiveMagnet(_activeTime);
    }
}