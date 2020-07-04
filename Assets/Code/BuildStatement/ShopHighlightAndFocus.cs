using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHighlightAndFocus : MonoBehaviour
{
    [SerializeField] private Material _material;
    public void HighlightAndFocusOn(CharacterAutoAim characterAutoAim)
    {
        characterAutoAim.AimCharacterToTarget(transform);
        _material.SetFloat("EmmisionMultiply", 1);
    }

    public void HighlightOff()
    {
        _material.SetFloat("EmmisionMultiply", 0);
    }
}
