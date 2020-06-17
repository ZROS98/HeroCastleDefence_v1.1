using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    private bool _attackAnimationIsActive = false;
    private Vector3 previousFrame;

    private void SetAttackAnimationIsActive(int eventValue)
    {
        _attackAnimationIsActive = eventValue == 1 ? true : false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_attackAnimationIsActive)
        {
            _animator.Play("Attack");
        }
        else if (!_attackAnimationIsActive && previousFrame == transform.position)
        {
            _animator.Play("Idle");
        }
        else if (!_attackAnimationIsActive && previousFrame != transform.position)
        {
            _animator.Play("Run");
        }
        previousFrame = transform.position;
    }
}
