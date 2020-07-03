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
    private GameObject _previousObject;
    private bool _previousObjectIsShop = false;
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
        
        Vector3 direction = new Vector3(1,0,1);
        Vector3 cameraDirection = Vector3.Scale((cinemachineFreeLook.transform.forward), (direction));
        

        Ray rayToMob = new Ray(_rayPosition, cameraDirection);

        Debug.DrawRay(_rayPosition, cameraDirection * _distanceToShop, Color.blue);

        if (Physics.Raycast(rayToMob, out RaycastHit hit, _distanceToShop))
        {
            int shopID = 0;
            if (hit.transform.CompareTag("Shop"))
            {
                hit.transform.GetComponent<Renderer>().material.SetFloat("EmmisionMultiply", 1);
                _previousObject = hit.transform.gameObject;
                _previousObjectIsShop = true;
            }
            else if (_previousObjectIsShop)
            {
                _previousObject.GetComponent<Renderer>().material.SetFloat("EmmisionMultiply", 0);
                _previousObjectIsShop = false;
            }
        }
        else if(_previousObject!=null && _previousObjectIsShop)
        {
            _previousObject.GetComponent<Renderer>().material.SetFloat("EmmisionMultiply",0);
            _previousObjectIsShop = false;
        }
           /* if (_previousObject!=null && _previousObject != hit.transform.gameObject)
            {
               // hit.transform.GetComponent<Renderer>().material.SetFloat("EmmisionMultiply",0);
            }*/
            //_previousShopID = shopID;
           
        
    }
}
