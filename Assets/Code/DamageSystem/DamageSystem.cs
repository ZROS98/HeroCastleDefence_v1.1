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
            Debug.Log("1");
            _scriptHolderIsMob = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackAnimationIsActive)
        {
            Debug.Log("2");
            if (_scriptHolderIsMob)
            {
                Debug.Log("3");
                if (other.TryGetComponent(out CharacterInfo characterInfo))
                {
                    Debug.Log("4");
                    characterInfo._healthPoint -= _weapon.damage;
                }
            }
            else 
            {
                if (other.TryGetComponent(out MobInfo mobInfo))
                {
                    Debug.Log("5");
                    mobInfo._healthPoint -= _weapon.damage;
                }
            }
        }
    }
}