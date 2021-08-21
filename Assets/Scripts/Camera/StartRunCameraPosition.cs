using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartRunCameraPosition : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private Vector3 _targetRotation;

    public void MoveCamera()
    {
        transform.DOLocalMove(_targetPosition, 1f);
        transform.DORotate(_targetRotation, 1f);
    }
}