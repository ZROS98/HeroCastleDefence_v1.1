using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class located on a mob
public class DamageSystem : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    public bool attackAnimationIsActive = false; //filling from animations event
    private bool _scriptHolderIsMob = false;
    void Start()
    {
        if(CompareTag("Mob"))
        {
            _scriptHolderIsMob = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackAnimationIsActive)
        {
            if (_scriptHolderIsMob)
            {
                if (other.TryGetComponent(out CharacterInfo characterInfo))
                {
                    characterInfo._healthPoint -= _weapon.damage;
                }
            }
            else 
            {
                if (other.TryGetComponent(out MobInfo mobInfo))
                {
                    mobInfo._healthPoint -= _weapon.damage;
                }
            }
        }
    }
}