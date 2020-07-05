using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Photon.Pun;
using UnityEditor.Rendering.HighDefinition;
using UnityEngine;

public class ShopInteraction : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private CharacterAutoAim _characterAutoAim;
    [SerializeField] private int _distanceToShop = 5;
    private Material _previousShopMaterial;
    private ShopHighlightAndFocus _shopHighlightAndFocus;
    private GameObject _previousObject;
    private int _previousShopID;
    private Vector3 _rayPosition;
    public CinemachineFreeLook cinemachineFreeLook;

    private void Awake()
    {
        if (!_photonView.IsMine) enabled = false;
    }

    private void Update()
    {
        _rayPosition = transform.position;
        _rayPosition.y = transform.position.y + 1;
        
        Vector3 direction = new Vector3(1, 0, 1);
        Vector3 cameraDirection = Vector3.Scale(cinemachineFreeLook.transform.forward, direction);  

        Ray rayToMob = new Ray(_rayPosition, cameraDirection);

        Debug.DrawRay(_rayPosition, cameraDirection * _distanceToShop, Color.blue);

        if (Physics.Raycast(rayToMob, out RaycastHit hit, _distanceToShop))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.CompareTag("Shop") && _previousObject == null)
            {
                _shopHighlightAndFocus = hitObject.GetComponent<ShopHighlightAndFocus>();
                _shopHighlightAndFocus.HighlightAndFocusOn(_characterAutoAim);
                _previousObject = hitObject;
            }
            else if (_previousObject != null && _previousObject != hitObject)
            {
                _shopHighlightAndFocus.HighlightOff();
                _previousObject = null;
            }
        }
        else if(_previousObject != null)
        {
            _shopHighlightAndFocus.HighlightOff();
            _previousObject = null;
        }       
    }
}
