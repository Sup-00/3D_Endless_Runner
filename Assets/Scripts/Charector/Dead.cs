using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharectorMoving), typeof(Score))]
public class Dead : MonoBehaviour
{
    [SerializeField] private UnityEvent OnShowLossScreen;

    private Score _score;
    private CharectorMoving _charectorMoving;

    private void Start()
    {
        _charectorMoving = FindObjectOfType<CharectorMoving>();
        _score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Barrier>())
        {
            OnShowLossScreen?.Invoke();
            _score.StopScoreAdding();
            _charectorMoving.StopMoving();
        }
    }
}