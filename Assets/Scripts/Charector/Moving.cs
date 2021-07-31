using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


[RequireComponent(typeof(Animator))]
public class Moving : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _distanceBetweenLine;
    [SerializeField] private float _jumpForce;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private UnityEvent _leftStrafe;
    [SerializeField] private UnityEvent _rightStrafe;
    [SerializeField] private UnityEvent _slide;
    [SerializeField] private UnityEvent _dead;

    private int _currentDirection = 1;
    private bool _isGrounded;
    private Animator _animator;
    private bool _isDead = false;

    public int CurrentDirection => _currentDirection;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * _runSpeed * Time.deltaTime;

        if (_isDead == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_currentDirection != 0)
                {
                    SideStrafe(-1);
                    _leftStrafe.Invoke();
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_currentDirection != 2)
                {
                    SideStrafe(1);
                    _rightStrafe.Invoke();
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) & _isGrounded)
            {
                transform.DOMoveY(transform.position.y + _jumpForce, 0.3f);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _boxCollider.enabled = false;
                _slide.Invoke();
            }
        }
    }

    private void SideStrafe(int side)
    {
        SetCurretDirection(side);
        transform.DOMoveX(_currentDirection * _distanceBetweenLine, 0.2f);
    }

    public void StopMoving()
    {
        _dead.Invoke();
        _runSpeed = 0;
        _isDead = true;
    }

    public void SetCurretDirection(int number)
    {
        if (_currentDirection <= 2 && _currentDirection >= 0)
            _currentDirection += number;
    }

    private void OnCollisionStay(Collision colision)
    {
        _isGrounded = true;
        _animator.SetBool("Jump", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
        _animator.SetBool("Jump", true);
    }
}