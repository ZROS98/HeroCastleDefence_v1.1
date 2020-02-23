using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HideOrShow : MonoBehaviour
{
    public void HideOrShowGameObject(GameObject _gameObject)
    {
        if (_gameObject != null)
        {
            bool isActive = _gameObject.activeSelf;
            _gameObject.SetActive(!isActive);
        }
    }

    
}
