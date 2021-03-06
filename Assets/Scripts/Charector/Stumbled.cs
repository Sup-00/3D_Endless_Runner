using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(CharectorMoving))]
public class Stumbled : MonoBehaviour
{
    [SerializeField] private UnityEvent OnHeat;

    private CharectorMoving _charectorMoving;

    private void Start()
    {
        _charectorMoving = FindObjectOfType<CharectorMoving>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SideBarrier>())
        {
            OnHeat?.Invoke();
            if (transform.position.x <= 0 || transform.position.x == 2.5 || transform.position.x >= 5)
            {
            }
            else if (_charectorMoving.CurrentDirection == 0)
            {
                transform.DOMoveX(2.5f, 0.2f);
                _charectorMoving.SetCurretDirection(1);
            }
            else if (_charectorMoving.CurrentDirection == 2)
            {
                transform.DOMoveX(2.5f, 0.2f);
                _charectorMoving.SetCurretDirection(-1);
            }
            else if (_charectorMoving.CurrentDirection == 1)
            {
                if (transform.position.x < 2.5)
                {
                    transform.DOMoveX(0f, 0.2f);
                    _charectorMoving.SetCurretDirection(-1);
                }
                else
                {
                    transform.DOMoveX(5f, 0.2f);
                    _charectorMoving.SetCurretDirection(1);
                }
            }
        }
    }
}