using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRespawnDeathController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private ThirdPersonMovement _thirdPersonMovement;
    private const int _respawnTime = 8;
    private bool _alreadyDead = false;
    public static CharacterRespawnDeathController current;
    public Transform spawnPoint;

    void Start()
    {
        CharacterHealthController.current.onTakeDamage += CheckForDeath;
    }

    /// <summary>
    /// true = respawn. False = death
    /// </summary>
    public event Action<bool> LifeStatusChanged;
    private void Death()
    {
        LifeStatusChanged?.Invoke(false);
        _alreadyDead = true;
        _animator.Play("Death");
        _thirdPersonMovement.stopMovement = true;
        _characterAnimation.dontChangeAnimation = true;
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(_respawnTime);
        LifeStatusChanged?.Invoke(true);
        _alreadyDead = false;

        transform.position = spawnPoint.position;
        CharacterHealthController.current.RestoreHealth();
        _thirdPersonMovement.stopMovement = false;
        _characterAnimation.dontChangeAnimation = false;
        _animator.Play("Idle");
    }

    private void CheckForDeath()
    {
        if (CharacterHealthController.current.GetHealth() < 0 && !_alreadyDead)
        {
            Death();
        }
    }
}
