using System;
using UnityEngine;

public class UpgradeAttackSpeed : MonoBehaviour
{
    private const float speedValueStep = 1;
    private CharacterAnimation _сharacterAnimation;
    private CharacterStatsInfo _characterStatsInfo;

    public void IncreaseAttackSpeed()
    {
        float currentAttackSpeed = _characterStatsInfo.attackSpeed;
        float newAttackSpeed = currentAttackSpeed + speedValueStep;

        _сharacterAnimation.ChangeAttackSpeed(newAttackSpeed);
        _characterStatsInfo.attackSpeed = newAttackSpeed;
    }

    private void Start()
    {
        _сharacterAnimation = CurrentCharacter.currentCharacter.GetComponent<CharacterAnimation>();
        _characterStatsInfo = CurrentCharacter.currentCharacter.GetComponent<CharacterStatsInfo>();
    }
}