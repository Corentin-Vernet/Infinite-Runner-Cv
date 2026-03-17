using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Mouve_Controller : MonoBehaviour
{
    [Header("Jump Parameters")]
    [SerializeField, Tooltip("seconde")] private float _jumpDuration = 2f;
    [SerializeField, Tooltip("metre")] private float _heightJump = 2f;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private AnimationCurve _fallCurve;

    [Header("Slide Parameters")]
    [SerializeField, Tooltip("seconde")] private float _slideDuration = 2f;
    [SerializeField] private Transform[] _slideTarget;

    [Header("Debug")]
    private int _currentLaneIndex = 2;
    private bool _isSliding;
    private bool _isJumping;
    private bool _isDead;

    private Coroutine _slideCoroutine;

    private void Start()
    {
        EventSystem.OnPlayerLifeUpdated += PlayerLife;
    }

    private void OnDestroy()
    {
        EventSystem.OnPlayerLifeUpdated -= PlayerLife;
    }

    private void PlayerLife(int playerLifeCount)
    {
        if (playerLifeCount == 0)
        {
            _isDead = true;           
        }
    }

    public void Update()
    {
        if (_isDead)
        { 
            return; 
        }

        HandleJump();
        HandleSlide();
    }

    private void HandleJump() // jump
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (_isJumping)
            {
                return;
            }

            StartCoroutine(routine: JumpCoroutine());
        }
    }

    private void HandleSlide() // slide left/right
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame) // left
        {
            if (_isSliding)
            {
                StopCoroutine(_slideCoroutine);
                _isSliding = false;
            }

            if (_currentLaneIndex == 0)
            {
                return;
            }

            _currentLaneIndex--;
            _slideCoroutine = StartCoroutine(routine: SlideCoroutine(_slideTarget[_currentLaneIndex]));
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame) // right
        {
            if (_isSliding)
            {
                StopCoroutine(_slideCoroutine);
                _isSliding = false;
            }

            if (_currentLaneIndex == _slideTarget.Length - 1)
            {
                return;
            }

            _currentLaneIndex++;
            _slideCoroutine = StartCoroutine(routine: SlideCoroutine(_slideTarget[_currentLaneIndex]));
        }
    }

    private IEnumerator JumpCoroutine()
    {
        _isJumping = true;
        var jumpTime = 0f;
        var halfJumpDuration = _jumpDuration / 2f;

        while (jumpTime < halfJumpDuration)
        {
            jumpTime += Time.deltaTime;
            var normalizedTime = jumpTime / halfJumpDuration;
            var heightTarget = _jumpCurve.Evaluate(normalizedTime) * _heightJump; // fait correspondre la hauteur du saut en fonction de ça durée
            var targetPosition = new Vector3(transform.position.x, heightTarget, transform.position.z);

            transform.position = targetPosition;

            yield return null; // attend la prochaine frame
        }

        jumpTime = 0f;

        while (jumpTime < halfJumpDuration)
        {
            jumpTime += Time.deltaTime;
            var normalizedTime = jumpTime / halfJumpDuration;
            var heightTarget = _fallCurve.Evaluate(normalizedTime) * _heightJump; // idem pour la chute
            var targetPosition = new Vector3(transform.position.x, heightTarget, transform.position.z);

            transform.position = targetPosition;

            yield return null; // attend la prochaine frame
        }

        _isJumping = false;
    }

    private IEnumerator SlideCoroutine(Transform target)
    {
        _isSliding = true;
        var slideTime = 1f;

        while (slideTime < _slideDuration)
        {
            slideTime += Time.deltaTime;
            var normalizedTime = slideTime / _slideDuration;
            var targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, normalizedTime);

            yield return null;
        }

        _isSliding = false;
    }
}