using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "New weapon", menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public string name;
    public int damage;
}
