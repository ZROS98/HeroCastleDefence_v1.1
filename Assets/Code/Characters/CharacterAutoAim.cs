using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAutoAim : MonoBehaviour
{
    [SerializeField] private int _rotationSpeed = 5;
    private void OnEnable()
    {
        EventManager.current.CharacterAimChanged += AimCharacterToTarget;
    }

    private void OnDisable()
    {
        EventManager.current.CharacterAimChanged -= AimCharacterToTarget;
    }

    private void AimCharacterToTarget(Transform target)
    {
       /* Vector3 targetPosition = target.position;
        targetPosition.y = 2;*/

        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
