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

    private int _currentDirection = 1;
    private bool _isGrounded;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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