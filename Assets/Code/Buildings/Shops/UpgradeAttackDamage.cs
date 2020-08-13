using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAttackDamage : MonoBehaviour
{
    private const float attackDamageValueStep = 5;
    private CharacterStatsInfo _characterStatsInfo;

    public void IncreaseAttackDamage()
    {
        float currentAttackDamage = _characterStatsInfo.attackDamage;
        _characterStatsInfo.attackDamage = attackDamageValueStep + currentAttackDamage;
    }

    private void Start()
    {
        _characterStatsInfo = CurrentCharacter.currentCharacter.GetComponent<CharacterStatsInfo>();
    }
}