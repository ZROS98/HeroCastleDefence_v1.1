﻿using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private PhotonView _photonView;
    public GameObject targetCharacter;
    public Animator animator;

    private void Awake()
    {
        if (!_photonView.IsMine) enabled = false;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToCharacter = Vector3.Distance(targetCharacter.transform.position, transform.position);

        if (distanceToCharacter <= _weapon.range && !IsInvoking())
        {
            //attacks animation is ON. Should make a normal delay instead 1f
            InvokeRepeating("StartAnimation", 0f, 1f);
        }
        else
        {
            CancelInvoke();
        }
    }

    private void StartAnimation()
    {
         Debug.Log("Invoke Works = mob attacking now");
         animator.Play("Attack");
    }
}
