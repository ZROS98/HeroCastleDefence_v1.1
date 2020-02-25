using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private GameObject _explosionVFX;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (_explosionVFX != null)
        {
            Instantiate(_explosionVFX, transform.position, transform.rotation);
        }
    }

    private void Start()
    {
        Destroy(gameObject,10f);
    }
}
