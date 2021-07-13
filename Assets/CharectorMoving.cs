using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody))]
public class CharectorMoving : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _distanceBetweenLine;
    [SerializeField] private UnityEvent _leftStrafe;
    [SerializeField] private UnityEvent _rightStrafe;

    private int _currentDirection = 1;

    private void Update()
    {
        transform.position += Vector3.forward * _runSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_currentDirection != 0)
            {
                _currentDirection--;
                transform.DOMoveX(transform.position.x - _distanceBetweenLine, 0.2f);
                _leftStrafe.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_currentDirection != 2)
            {
                _currentDirection++;
                transform.DOMoveX(transform.position.x + _distanceBetweenLine, 0.2f);
                _rightStrafe.Invoke();
            }
        }
    }
}