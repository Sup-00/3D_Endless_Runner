using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class Booster : MonoBehaviour
{
    [SerializeField] private Vector3 _targetSize;

    protected void ScaleBooster()
    {
        transform.DOScale(_targetSize, 1f).SetLoops(-1, LoopType.Yoyo);
    }
    
    protected void OnTriggerEnter(Collider other)
    {
        Boost();
        gameObject.SetActive(false);
    }

    protected abstract void Boost();
}