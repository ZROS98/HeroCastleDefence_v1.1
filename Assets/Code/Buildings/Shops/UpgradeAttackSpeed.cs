using System;
using UnityEngine;

public class UpgradeAttackSpeed : MonoBehaviour
{
    private const float speedValueStep = 1;
    private Animator _animator;
    private CharacterStatsInfo _characterStatsInfo;

    public void IncreaseAttackSpeed()
    {
        float currentAttackSpeed = _characterStatsInfo.attackSpeed;
        float newAttackSpeed = currentAttackSpeed + speedValueStep;

        _animator.SetFloat("AttackSpeed", newAttackSpeed);
        _characterStatsInfo.attackSpeed = newAttackSpeed;
    }

    private void Start()
    {
        _animator = CurrentCharacter.currentCharacter.GetComponent<Animator>();
        _characterStatsInfo = CurrentCharacter.currentCharacter.GetComponent<CharacterStatsInfo>();
    }
}