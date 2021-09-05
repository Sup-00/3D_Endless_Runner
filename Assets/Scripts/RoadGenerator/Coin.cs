using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CharectorMoving _charectorMoving;
    private bool _isBoosted = false;

    private void Update()
    {
        if (_isBoosted)
            transform.DOMove(_charectorMoving.transform.position, 0.4f);
    }

    private void Start()
    {
        _charectorMoving = FindObjectOfType<CharectorMoving>();
        RotateCoin();
    }

    private void RotateCoin()
    {
        Tween tween = transform.DORotate(new Vector3(0f, 350f, 0f), 2, RotateMode.FastBeyond360);
        tween.SetLoops(-1, LoopType.Restart);
        tween.SetEase(Ease.Linear);
    }

    public void ActiveBooster(bool state)
    {
        _isBoosted = state;
    }
}