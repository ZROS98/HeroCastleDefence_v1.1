using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCharacterToMob : MonoBehaviour
{
    [SerializeField] private int _numberLayerCharacter = 9;
    private const int maxRaycastDistance = 100;
    private int _layerMask;

    void Start()
    {
        // Bit shift the index of the layer (_numberLayerCharacter) to get a bit mask
        _layerMask = 1 << _numberLayerCharacter;
        // This would cast rays only against colliders in layer 9.
        // But instead we want to collide against everything except layer 9. The ~ operator does this, it inverts a bitmask.
        _layerMask = ~ _numberLayerCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rayToMob = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(rayToMob, out hit, Mathf.Infinity, _layerMask))
        {
            if (hit.collider.CompareTag("Mob"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
