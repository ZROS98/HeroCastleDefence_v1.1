/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class located on a weapon
public class DamageSystem : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private bool attackMobs = false;
    void Start()
    {
        if(!this.CompareTag("Mob"))
        {
            attackMobs = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isAttackAnimation = false; //
        //isAttackAnimation = this.Animation.name("Attack");
        if (isAttackAnimation)
        {
            if (attackMobs)
            {
                if (other.CompareTag("Mob"))
                {
                    other.GetComponent<MobInfo>()._healthPoint -= _weapon.damage;
                }
                else if (other.CompareTag("Player1") || other.CompareTag("Player2"))
                {
                    other.GetComponent<CharacterInfo>().-= _weapon.damage;
                }
            }
            else
            {
                if (!other.CompareTag("Mob"))
                {
                    //damage
                }
            }
        }
    }
}
*/