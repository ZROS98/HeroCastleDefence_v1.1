using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{

    public int _healthPoint = 100;


    /*public GameObject SliderButton;

    private void ChangeValueSlider()
    {
        var Slider = SliderButton.GetComponent<Slider>();
        Slider.value = _healthPoint;
    }
    
    private void Update()
    {
        ChangeValueSlider();
        if (_healthPoint < 1)
        {
            PhotonView.Get(this).RPC("DeathRPC", RpcTarget.All);
        }
    }

    [PunRPC]
    private void DeathRPC()
    {
        gameObject.GetComponent<Animator>().Play("Death");
        //Show DeathAnimation and use cooldown on characters respawn.
    }

    private void TookDamage(int damage)
    {
        Debug.Log(damage);
        _healthPoint = _healthPoint - damage;
    }
    
    
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("MobWeapon")) //&& mob (collision) has AttackAnimationIsOn
        {          
            Animator animator = collider.transform.root.GetComponentInParent<Animator>();
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                TookDamage(collider.transform.root.GetComponent<WeaponInfo>().damage);    
            }         
        }
    }*/
}
