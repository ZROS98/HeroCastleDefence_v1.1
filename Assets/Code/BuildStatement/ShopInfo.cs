using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfo : MonoBehaviour
{
    [SerializeField] private ShopHighlight _shopHighlight;
    [SerializeField] private ShopAimCharacter _shopAimCharacter;
    public int shopId;
    private bool _shopInTarget = false;

    public void SetShopInTarget(bool shopInTarget, CharacterAutoAim characterAutoAim = null)
    {
        _shopInTarget = shopInTarget;

        if (_shopInTarget)
        {
            _shopHighlight.ShopInTarget(shopInTarget);
            _shopAimCharacter.CharacterAim(characterAutoAim);
        }
        else
        {
            _shopHighlight.ShopInTarget(shopInTarget);
        }
    }
}
