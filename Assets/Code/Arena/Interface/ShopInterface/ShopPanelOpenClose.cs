using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelOpenClose : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void OpenShopPanel()
    {
        _panel.SetActive(true);
    }

    public void CloseShopPanel()
    {
        _panel.SetActive(false);
    }
}
