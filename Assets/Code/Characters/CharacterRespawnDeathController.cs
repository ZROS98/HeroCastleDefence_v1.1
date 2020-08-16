using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRespawnDeathController : MonoBehaviour
{
    [SerializeField] private CharacterHealthController _characterHealthController;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private ThirdPersonMovement _thirdPersonMovement;
    private const int _respawnTime = 8;
    private bool _alreadyDead = false;
    public Transform spawnPoint;

    private void Death()
    {
        _alreadyDead = true;
        _characterAnimation.SetIsDead(true);
        _thirdPersonMovement.SetStopMovement(true);
        StartCoroutine("Respawn");

        EventManager.current.OnLifeStatusDeath();
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(_respawnTime);
        _alreadyDead = false;

        transform.position = spawnPoint.position;
        _characterHealthController.RestoreHealth();
        _thirdPersonMovement.SetStopMovement(false);
        _characterAnimation.SetIsDead(false);

        EventManager.current.OnLifeStatusRespawn();
    }

    public void CheckForDeath(int healthPoint)
    {
        if (healthPoint < 1 && !_alreadyDead)
        {
            Death();
        }
    }
}
