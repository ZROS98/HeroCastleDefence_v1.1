using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    public GameObject mainCamera;
    private PhotonView _PV;
    public GameObject SliderButton;

    
    public void Start()
    {
        _PV = gameObject.GetComponent<PhotonView>();
        if (_PV.IsMine)
        {
            _PV.RPC("SpawnCharacter", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void SpawnCharacter() //do it once
    {
        GameObject currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
            new Vector3(25,1,85), Quaternion.identity);


        currentCharacter.GetComponent<Movement>().chrCamera = mainCamera;
        gameObject.GetComponent<TurnOffPlayerControl>().charactersArray.Add(currentCharacter);
        currentCharacter.GetComponent<CharacterInfo>().SliderButton = SliderButton;
    }
    
}