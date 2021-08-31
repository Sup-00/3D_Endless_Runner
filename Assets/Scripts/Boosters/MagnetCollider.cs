using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCollider : MonoBehaviour
{
    [SerializeField] private BoosterUI _boosterUI;

    private bool _isBoosted = false;
    private Moving _moving;

    private void Awake()
    {
        _moving = FindObjectOfType<Moving>();
    }

    public void ActiveMagnet(float activeTime)
    {
        if (_isBoosted == false)
        {
            GetComponent<BoxCollider>().enabled = true;
            _isBoosted = true;
            _boosterUI.ShowMagnetUI(activeTime);
            StartCoroutine(ActiveTimer(activeTime));
        }
    }

    private IEnumerator ActiveTimer(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        _isBoosted = false;
        GetComponent<BoxCollider>().enabled = false;
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
}