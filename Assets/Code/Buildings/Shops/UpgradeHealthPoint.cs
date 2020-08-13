using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class UpgradeHealthPoint : MonoBehaviour
{

    private const float healthPointsValueStep = 10;
    private CharacterStatsInfo _characterStatsInfo;

    public void IncreaseHealthPoint()
    {
        float currentHealthPoint = _characterStatsInfo.healthPoint;
        _characterStatsInfo.healthPoint = healthPointsValueStep + currentHealthPoint;
    }

    private void Start()
    {
        _characterStatsInfo = CurrentCharacter.currentCharacter.GetComponent<CharacterStatsInfo>();
    }
}
