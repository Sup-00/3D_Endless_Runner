using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private float _score = 0;

    private int _addScoreSize = 30;

    private void Update()
    {
         _score += _addScoreSize * Time.deltaTime;
        _scoreText.text = _score.ToString("#");
    }
}
