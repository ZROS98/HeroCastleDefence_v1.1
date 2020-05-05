using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon; 
    public GameObject enemyCharacter;

    void Update()
    {
        float distanceToCharacter = Vector3.Distance(enemyCharacter.transform.position, transform.position);

        if (distanceToCharacter <= _weapon.range)
        {
            //attacks animation is ON. It's meaning than Coroutine should calls AttackAnimation every _weapon.speed
        }
        else
        {
            //attacks animation is OFF. It's meaning Coroutine should be OFF
        }
    }
}
