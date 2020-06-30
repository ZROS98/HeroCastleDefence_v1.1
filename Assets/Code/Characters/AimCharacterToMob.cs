using Photon.Pun;
using System;
using UnityEngine;

public class AimCharacterToMob : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PhotonView _photonView;
    private const int maxRaycastDistance = 100;
    private GameObject previousObject;
    private Vector3 _rayPosition;
    private int _mobPhotonViewID;

    private void Start()
    {
        _mobPhotonViewID = _photonView.ViewID;
    }

    private void Update()
    {
        _rayPosition = transform.position;
        _rayPosition.y = transform.position.y + 1;
        Ray rayToMob = new Ray(_rayPosition, transform.forward);

        Debug.DrawRay(_rayPosition, transform.forward * 200,Color.red);

        if (Physics.Raycast(rayToMob, out RaycastHit hit, Mathf.Infinity, _layerMask))
        {
            if (hit.transform.CompareTag("Mob"))
            {
                EventManager.current.OnMobHighlightingTurnOn(_mobPhotonViewID);
            }

            if (previousObject != hit.transform.gameObject)
            {
                EventManager.current.OnMobHighlightingTurnOff(_mobPhotonViewID);
            }
            previousObject = hit.transform.gameObject;
        }
    }
}
