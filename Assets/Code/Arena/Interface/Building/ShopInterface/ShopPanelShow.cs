using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelShow : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private bool _pressFPanelShown = false;
    public static bool shopPanelShown = false;

    public void SetPressFPanelShown(bool pressFPanelShown)
    {
        if (!pressFPanelShown) _shopPanel.SetActive(false);

        _pressFPanelShown = pressFPanelShown;
    }

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (_pressFPanelShown) _shopPanel.SetActive(!_shopPanel.activeSelf);
            shopPanelShown = true;
        }
    }
}
