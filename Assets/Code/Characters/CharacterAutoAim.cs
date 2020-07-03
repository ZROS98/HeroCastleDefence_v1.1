using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAutoAim : MonoBehaviour
{
    [SerializeField] private int _rotationSpeed = 5;
    private void OnEnable()
    {
        EventManager.current.CharacterAimChanged += AimCharacterToMob;
    }

    private void OnDisable()
    {
        EventManager.current.CharacterAimChanged -= AimCharacterToMob;
    }

    private void AimCharacterToMob(Transform mob)
    {
        Quaternion targetRotation = Quaternion.LookRotation(mob.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
