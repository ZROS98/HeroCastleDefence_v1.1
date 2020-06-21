using Photon.Pun;
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

        //Mathf.Infinity
        if (Physics.Raycast(rayToMob, out hit, 10000, _layerMask))
        {
            if (hit.collider.CompareTag("Mob"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //PhotonNetwork.Destroy(hit.transform.gameObject);
                Debug.Log(hit.transform.gameObject);
            }
        }
    }
}
