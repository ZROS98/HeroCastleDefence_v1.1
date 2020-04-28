using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    public GameObject mainCamera;
    private PhotonView _PV;

    public void Start()
    {
        _PV = gameObject.GetComponent<PhotonView>();
        if (_PV.IsMine)
        {
            _PV.RPC("SpawnCharacter", RpcTarget.AllBuffered);
        }

    }
    [PunRPC]
    private void SpawnCharacter()
    {
        GameObject currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
            new Vector3(20, 1, 70), Quaternion.identity);

        currentCharacter.GetComponent<Movement>().chrCamera = mainCamera;
        gameObject.GetComponent<TurnOffPlayerControl>().character = currentCharacter;

    }
}