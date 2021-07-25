using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        RotateCoin();
    }

    private void RotateCoin()
    {
        Tween tween = transform.DORotate(new Vector3(0f, 350f, 0f), 2, RotateMode.FastBeyond360);
        tween.SetLoops(-1, LoopType.Restart);
        tween.SetEase(Ease.Linear);
    }
}
