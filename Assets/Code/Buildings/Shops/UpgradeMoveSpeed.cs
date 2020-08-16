using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMoveSpeed : MonoBehaviour
{
    private const float speedValueStep = 1;
    private float speedMoveAnimation = 1;
    private CharacterAnimation _сharacterAnimation;
    private CharacterStatsInfo _characterStatsInfo;
    private ThirdPersonMovement _thirdPersonMovement;


    public void IncreaseMoveSpeed()
    {
        _characterStatsInfo.moveSpeed += speedValueStep;
        _thirdPersonMovement.SetNewMoveSpeed();
        _сharacterAnimation.ChangeMoveSpeed(NewSpeedMoveAnimation());
    }

    private float NewSpeedMoveAnimation()
    {
        float percentAcceleration = speedValueStep / _characterStatsInfo.moveSpeed;
        speedMoveAnimation += speedMoveAnimation * percentAcceleration;
        return speedMoveAnimation;
    }

    private void Start()
    {
        _сharacterAnimation = CurrentCharacter.currentCharacter.GetComponent<CharacterAnimation>();
        _characterStatsInfo = CurrentCharacter.currentCharacter.GetComponent<CharacterStatsInfo>();
        _thirdPersonMovement = CurrentCharacter.currentCharacter.GetComponent<ThirdPersonMovement>();
    }

}