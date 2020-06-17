using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    public bool attackAnimationIsActive = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attackAnimationIsActive)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _animator.Play("Attack");
        }
        else if (!attackAnimationIsActive && _rigidbody.velocity == new Vector3(0f, 0f, 0f))
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            _animator.Play("Idle");
        }
        else if (!attackAnimationIsActive && _rigidbody.velocity != new Vector3(0f, 0f, 0f))
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            _animator.Play("Run");
        }
    }
}
