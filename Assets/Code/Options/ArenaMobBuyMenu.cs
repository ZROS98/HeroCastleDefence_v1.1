using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMobBuyMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && _gameObject != null) 
        {
            bool isActive = _gameObject.activeSelf;
            _gameObject.SetActive(!isActive);
        }
    }
}
