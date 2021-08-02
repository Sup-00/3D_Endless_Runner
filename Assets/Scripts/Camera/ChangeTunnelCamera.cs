using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeTunnelCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] float _inTunnelXRotation;
    [SerializeField] float _inTunnelYPosition;

    private float _defaultXRotation = 20f;
    private float _defaultYPosition = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TunnelEnter>())
        {
            MoveCamera(_inTunnelYPosition, _inTunnelXRotation);
        }

        if (other.GetComponent<TunnelExit>())
        {
            MoveCamera(_defaultYPosition, _defaultXRotation);
        }
    }

    private void MoveCamera(float YPosition, float XRotation)
    {
        _camera.transform.DOMoveY(YPosition, 0.5f);
        _camera.transform.DORotate(new Vector3(XRotation, _camera.transform.localRotation.y), 0.5f);
    }
}