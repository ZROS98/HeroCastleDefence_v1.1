using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon; 
    public GameObject enemyCharacter;
    public Animator animator;

    private void Start()
    {
        animator = enemyCharacter.GetComponent<Animator>();
        
    }

    void Update()
    {
        float distanceToCharacter = Vector3.Distance(enemyCharacter.transform.position, transform.position);

        if (distanceToCharacter <= _weapon.range)
        {
            //attacks animation is ON. It's meaning than Coroutine should calls AttackAnimation every _weapon.delay
            StartCoroutine(" StartAnimation", true);
            StartCoroutine(StartAnimation(true));
        }
        else
        {
            //attacks animation is OFF. It's meaning Coroutine should be OFF
            StartCoroutine("StartAnimation", false);
        }
        
        IEnumerator StartAnimation(bool animationIsActive)
        {
            while (animationIsActive)
            {
                yield return new  WaitForSeconds(_weapon.delay);
                Debug.Log("Courotine Works");
                animator.Play("Attack");   
            }
        }
    }
}
