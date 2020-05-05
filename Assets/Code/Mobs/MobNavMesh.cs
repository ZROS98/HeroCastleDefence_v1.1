using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class MobNavMesh : MonoBehaviourPun
{
    [SerializeField] private Transform _destinationCastle;
    [SerializeField] private Transform _destinationPlayer;
    private float _distanceDifference;
    private NavMeshAgent _navMeshAgent;
    private PhotonView _PV;
    private MobAttack _mobAttack;

    private void Start()
    {
        _mobAttack = GetComponent<MobAttack>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _PV = GetComponent<PhotonView>();
        ChooseTarget();
    }

    private void ChooseTarget()
    {
        GameObject player1 = GameObject.FindWithTag("Player1");
        GameObject player2 = GameObject.FindWithTag("Player2");
        PhotonView photonViewPlayer1 = player1.GetComponent<PhotonView>();
        PhotonView photonViewPlayer2 = player2.GetComponent<PhotonView>();
        if (_PV.Owner == photonViewPlayer1.Owner)
        {
            _destinationPlayer = player2.transform;
            _mobAttack.enemyCharacter = player2;
        }else if (_PV.Owner == photonViewPlayer2.Owner)
        {
            _destinationPlayer = player1.transform;
            _mobAttack.enemyCharacter = player1;
        }
    }

    private void Update()
    {
        _distanceDifference = Vector3.Distance(_destinationPlayer.position, transform.position);
        if (_distanceDifference <= 10)
        {
            Debug.Log("Current target is Player");
            SetDestinationToPlayer();
        }
        else
        {
            Debug.Log("Current target is castle");
            SetDestinationToCastle();
        }
    }

    private void SetDestinationToCastle()
    {
        if(_destinationCastle!=null)
        {
            Vector3 targetVector = _destinationCastle.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    private void SetDestinationToPlayer()
    {
        if (_destinationPlayer != null)
        {
            Vector3 targetVector = _destinationPlayer.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            
        }
    }
    
}
