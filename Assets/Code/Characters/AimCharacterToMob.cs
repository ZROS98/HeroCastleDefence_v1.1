using Photon.Pun;
using System;
using UnityEngine;

public class AimCharacterToMob : MonoBehaviour
{
    private const int maxRaycastDistance = 100;
    private GameObject previousObject;
    private int _previousMobID;
    private Vector3 _rayPosition;

    private void Update()
    {
        _rayPosition = transform.position;
        _rayPosition.y = transform.position.y + 1;
        Ray rayToMob = new Ray(_rayPosition, transform.forward);

        Debug.DrawRay(_rayPosition, transform.forward * 200,Color.red);

        if (Physics.Raycast(rayToMob, out RaycastHit hit, Mathf.Infinity))
        {
            int mobID = 0;
            if (hit.transform.CompareTag("Mob"))
            {
                Debug.Log("Name object's with tag Mob: " + hit.transform.gameObject.name);
                mobID = hit.transform.GetComponent<PhotonView>().ViewID;
                EventManager.current.OnMobHighlightingTurnOn(mobID);
            }

            if (previousObject!=null && previousObject.CompareTag("Mob") && previousObject != hit.transform.gameObject)
            {
                EventManager.current.OnMobHighlightingTurnOff(_previousMobID);
            }
            _previousMobID = mobID;
            previousObject = hit.transform.gameObject;
        }
    }
}
