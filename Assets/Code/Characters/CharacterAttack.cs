using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private DamageSystem _damageSystem;
    private bool _attackAnimationIsActive = false;

    private void SetAttackAnimationIsActive(int eventValue)
    {
        _attackAnimationIsActive = eventValue == 1 ? true : false;
        _damageSystem.attackAnimationIsActive = _attackAnimationIsActive;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_attackAnimationIsActive)
        {
            _characterAnimation.SetIsAttacking();
        }
    }
}
