using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    [SerializeField] private Rigidbody _projectile;
    [SerializeField] private float _projectileSpeed = 20f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody clone = Instantiate(_projectile, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * _projectileSpeed);
        }
    }
}
