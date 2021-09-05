using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private UnityEvent OnBoost;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private float _score = 0;
    [SerializeField] private int _startAddScoreSize;

    private int _addScoreSize;
    private bool _isBoosted = false;

    public float PlayerScore => _score;

    private void Start()
    {
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
            OnBoost?.Invoke();
            StartCoroutine(ActiveTimer(activeTime));
        }
    }
}