using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsInfo : MonoBehaviour
{
    [SerializeField] private CharacterStats _characterStats;

    [SerializeField] private float _healthPoint;
    private float defencePoint;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpeed;
    private float skillCooldownSpeed;
    private float castSpeed;
    [SerializeField] private float _attackDamage;
    private float skillDamage;

    private void Start()
    {
        _attackSpeed = _characterStats.attackSpeed;
        _moveSpeed = _characterStats.moveSpeed;
        _healthPoint = _characterStats.healthPoint;
        _attackDamage = _characterStats.attackDamage;
    }

    public float moveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }

    public float attackSpeed
    {
        get => _attackSpeed;
        set => _attackSpeed = value;
    }
    
    public float healthPoint
    {
        get => _healthPoint;
        set => _healthPoint = value;
    }
    
    public float attackDamage
    {
        get => _attackDamage;
        set => _attackDamage = value;
    }
}