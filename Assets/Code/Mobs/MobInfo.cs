using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobInfo : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _weapon;
    [SerializeField] private string name;
    
    public int _healthPoint = 100;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (_healthPoint<1)
        {
            PhotonView.Get(this).RPC("DestroyMob", RpcTarget.All);
        }
    }

    [PunRPC]
    private void DestroyMob()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    private void TakeDamage(int damage)
    {
        _healthPoint -= damage;
    }

}
