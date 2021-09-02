using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private float _score = 0;
    [SerializeField] private int _startAddScoreSize;
    [SerializeField] private BoosterUI _boosterUI;

    private int _addScoreSize;
    private bool _isBoosted = false;

    public float PlayerScore => _score;

    private void Start()
    {
        //_boosterUI = FindObjectOfType<BoosterUI>();
        _addScoreSize = _startAddScoreSize;
    }

    private void Update()
    {
        _score += _addScoreSize * Time.deltaTime;
        _scoreText.text = _score.ToString("#");
    }

    private IEnumerator ActiveTimer(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        _addScoreSize = _startAddScoreSize;
        _isBoosted = false;
    }

    public void StopScoreAdding()
    {
        _addScoreSize = 0;
    }

    public void MultiplayScore(int multiplayer, float activeTime)
    {
        if (_isBoosted == false)
        {
            _addScoreSize *= multiplayer;
            _isBoosted = true;
            _boosterUI.ShowScoreBoostUI(activeTime);
            StartCoroutine(ActiveTimer(activeTime));
        }
    }
}