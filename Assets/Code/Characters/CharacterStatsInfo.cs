using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsInfo : MonoBehaviour
{
    [SerializeField] private CharacterStats _characterStats;
    
    [SerializeField] private float healthPoint;
    [SerializeField] private float defencePoint;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float skillCooldownSpeed;
    [SerializeField] private float castSpeed;
    [SerializeField] private float attackDamage;
    [SerializeField] private float skillDamage;
    
    private void Start()
    {
        _attackSpeed = _characterStats.attackSpeed;
    }

    public void SetAttackSpeed(float attackSpeed)
    {
        _attackSpeed = attackSpeed;
    }

    public float GetAttackSpeed()
    {
        return _attackSpeed;
    }

}
