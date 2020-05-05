using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public int _healthPoint = 100;

    private void Update()
    {
        if (_healthPoint < 1)
        {
            PhotonView.Get(this).RPC("RIP", RpcTarget.All);
        }
    }

    [PunRPC]
    private void RIP()
    {
        //Show DeathAnimation and use cooldown on characters respawn.
    }

    private void TakedDamage(int damage)
    {
        _healthPoint -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MobWeapon")) //&& mob (collision) has AttackAnimationIsOn
        {
            TakedDamage(collision.gameObject.GetComponent<WeaponInfo>().damage);
        }
    }


}
