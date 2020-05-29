﻿using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class MobNavMesh : MonoBehaviourPun
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private PhotonView _photonView;
    private float _distanceDifference;
    private const int _agrOnPlayerDistance = 10;
    public Transform targetCharacterTransform;
    public Vector3 targetCastlePosition;

    private void Awake()
    {
        if (!_photonView.IsMine) enabled = false; //new idea.     
    }

    private void Update()
    {
        Vector3 targetCharacterPosition = targetCharacterTransform.position;
        _distanceDifference = Vector3.Distance(targetCharacterPosition, transform.position);

        if (_distanceDifference <= _agrOnPlayerDistance)
        {
            _navMeshAgent.SetDestination(targetCharacterPosition);
        }
        else
        {
            _navMeshAgent.SetDestination(targetCastlePosition);
        }
    }  
}
