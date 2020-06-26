using System;
using UnityEngine;

public class AimCharacterToMob : MonoBehaviour
{
    [SerializeField] private int _numberLayerCharacter = 9;
    private const int maxRaycastDistance = 100;
    private GameObject previousObject;
    private Vector3 _rayPosition;
    

    private void Update()
    {
        _rayPosition = transform.position;
        _rayPosition.y = transform.position.y + 1;
        OnDrawGizmos();
        Ray rayToMob = new Ray(_rayPosition, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(rayToMob, out RaycastHit hit, Mathf.Infinity, _numberLayerCharacter))
        {
           
            if (hit.transform.CompareTag("Mob"))
            {
                EventManager.current.OnMobHighlightingTurnOn();
            }

            if (previousObject != hit.transform.gameObject)
            {
                EventManager.current.OnMobHighlightingTurnOff();
            }
            previousObject = hit.transform.gameObject;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 100;
        Gizmos.DrawLine(_rayPosition, direction);
    }
}
