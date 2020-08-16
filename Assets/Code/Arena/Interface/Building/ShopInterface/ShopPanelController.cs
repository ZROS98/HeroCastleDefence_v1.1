using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private bool _pressFPanelShown = false;
    private float _waitingTime;
    private const float _buttonCooldown = 1f;
    public bool shopPanelShown = false;

    private void Update()
    {
        if (Input.GetKeyUp("f"))
        {
            if (_pressFPanelShown)
            {
                _shopPanel.SetActive(true);
                shopPanelShown = true;
                CharacterSwitchControl.current.CharacterControlTurnOff();
            }
            else
            {
                CloseShopPanel();                
            }
        }
    }

    public void SetPressFPanelShown(bool pressFPanelShown)
    {
        if (!pressFPanelShown && !shopPanelShown) _shopPanel.SetActive(false);

        _pressFPanelShown = pressFPanelShown;
    }

    public void CloseShopPanel()
    {
        _shopPanel.SetActive(false);
        shopPanelShown = false;
        CharacterSwitchControl.current.CharacterControlTurnOn();
    }
}
