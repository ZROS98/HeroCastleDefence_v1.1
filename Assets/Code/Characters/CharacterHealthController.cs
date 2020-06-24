using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : MonoBehaviour, IDamageHadler
{
    public static CharacterHealthController current;
    [SerializeField] private int _healthPoint = 100;

    private void Awake()
    {
        current = this;
    }

    public event Action onTakeDamage;
    public void TakeDamage(int damage)
    {
        _healthPoint -= damage;
    }

    public int GetHealth()
    {
        return _healthPoint;
    }

    public void RestoreHealth()
    {
        _healthPoint = 100;
    }
}
