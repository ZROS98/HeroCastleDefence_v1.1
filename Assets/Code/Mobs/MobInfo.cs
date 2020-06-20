using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobInfo : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _weapon;
    [SerializeField] private string name;
    
    public int _healthPoint = 100;

    public void TakeDamage(int damage)
    {
        _healthPoint -= damage;

        if (_healthPoint <= 0)
        {
            // _photonView.RPC("DestroyRPC", RpcTarget.AllBuffered);
            PhotonNetwork.Destroy(gameObject);
        }
    }

    [PunRPC]
    private void DestroyRPC()
    {
        PhotonNetwork.Destroy(gameObject);
    }

}
