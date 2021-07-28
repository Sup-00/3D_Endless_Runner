using UnityEngine;
using UnityEngine.Events;

public class Hit : MonoBehaviour
{
    [SerializeField] private UnityEvent _showLoseScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Barrier>())
        {
            _showLoseScreen.Invoke();
            Time.timeScale = 0;
        }
    }
}