using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Stumbled : MonoBehaviour
{
    [SerializeField] private UnityEvent _hited;

    private Moving _moving;

    private void Start()
    {
        _moving = FindObjectOfType<Moving>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SideBarrier>())
        {
            _hited.Invoke();
            if (transform.position.x <= 0 || transform.position.x == 2.5 || transform.position.x >= 5)
            {
            }
            else if (_moving.CurrentDirection == 0)
            {
                transform.DOMoveX(2.5f, 0.2f);
                _moving.SetCurretDirection(1);
            }
            else if (_moving.CurrentDirection == 2)
            {
                transform.DOMoveX(2.5f, 0.2f);
                _moving.SetCurretDirection(-1);
            }
            else if (_moving.CurrentDirection == 1)
            {
                if (transform.position.x < 2.5)
                {
                    transform.DOMoveX(0f, 0.2f);
                    _moving.SetCurretDirection(-1);
                }
                else
                {
                    transform.DOMoveX(5f, 0.2f);
                    _moving.SetCurretDirection(1);
                }
            }
        }
    }
}