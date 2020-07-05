using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHighlight : MonoBehaviour
{
    [SerializeField] private Material _material;

    public void ShopInTarget(bool shopInTarget)
    {
        if (shopInTarget)
        {
            ShopHighlightOn();
        }
        else
        {
            ShopHighlightOff();
        }
    }

    private void ShopHighlightOn()
    {
        _material.SetFloat("EmissionMultiply", 1);
    }

    private void ShopHighlightOff()
    {
        _material.SetFloat("EmissionMultiply", 0);
    }
}
