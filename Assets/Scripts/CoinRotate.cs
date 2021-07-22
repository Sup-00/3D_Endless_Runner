using DG.Tweening;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    private void Start()
    {
        Tween tween = transform.DORotate(new Vector3(0f, 350f, 0f), 2, RotateMode.FastBeyond360);
        tween.SetLoops(-1, LoopType.Restart);
        tween.SetEase(Ease.Linear);
    }
}
