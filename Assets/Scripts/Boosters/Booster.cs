using DG.Tweening;
using UnityEngine;

public abstract class Booster : MonoBehaviour
{
    [SerializeField] private Vector3 _targetSize;

    protected float ActiveTime = 10f;

    public void SetActiveTime(float time)
    {
        ActiveTime = time;
    }

    protected void ScaleBooster()
    {
        transform.DOScale(_targetSize, 1f).SetLoops(-1, LoopType.Yoyo);
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        Boost();
        gameObject.SetActive(false);
    }

    protected abstract void Boost();
}