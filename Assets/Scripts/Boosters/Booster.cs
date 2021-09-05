using DG.Tweening;
using UnityEngine;

public abstract class Booster : MonoBehaviour
{
    [SerializeField] private Vector3 _targetSize;

    public float ActiveTime { get; private set; }


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