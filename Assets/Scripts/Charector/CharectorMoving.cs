using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


[RequireComponent(typeof(Animator), typeof(Score))]
public class CharectorMoving : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _distanceBetweenLine;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private UnityEvent OnLeftStrafe;
    [SerializeField] private UnityEvent OnRightStrafe;
    [SerializeField] private UnityEvent OnSlide;
    [SerializeField] private UnityEvent OnDead;

    private int _currentDirection = 1;
    private bool _isGrounded;
    private bool _isDead = false;
    private bool _isBoosted = false;

    private const string START_GAME_ANIMATION = "StartGame";
    private const string JUMP_ANIMATION = "Jump";

    public int CurrentDirection => _currentDirection;
    public float JumpForce => _jumpForce;
    public bool IsBooted => _isBoosted;

    private void Start()
    {
        _animator.SetTrigger(START_GAME_ANIMATION);
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
                    OnLeftStrafe?.Invoke();
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_currentDirection != 2)
                {
                    SideStrafe(1);
                    OnRightStrafe?.Invoke();
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) & _isGrounded)
            {
                transform.DOMoveY(transform.position.y + _jumpForce, 0.3f);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _boxCollider.enabled = false;
                OnSlide?.Invoke();
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
        OnDead?.Invoke();
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
        _animator.SetBool(JUMP_ANIMATION, false);
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
        _animator.SetBool(JUMP_ANIMATION, true);
    }

    public void SetJumpBooster(float jumpForce, bool isBoosted)
    {
        _jumpForce = jumpForce;
        _isBoosted = isBoosted;
    }
}