using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : MonoBehaviour, IDamageHadler
{
    [SerializeField] private int _healthPoint = 100;
    [SerializeField] private PhotonView _photonView;
    public static CharacterHealthController current;

    private void Awake()
    {
        if (!_photonView.IsMine) enabled = false;
        current = this;
    }

    public event Action onTakeDamage;
    public void TakeDamage(int damage)
    {
        _healthPoint -= damage;

        onTakeDamage?.Invoke();
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
