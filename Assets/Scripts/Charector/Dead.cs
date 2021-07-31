using System;
using UnityEngine;
using UnityEngine.Events;

public class Dead : MonoBehaviour
{
    private Score _score;
    private Moving _moving;

    private void Start()
    {
        _moving = FindObjectOfType<Moving>();
        _score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Barrier>())
        {
            _score.StopScoreAdding();
            _moving.StopMoving();
        }
    }
}