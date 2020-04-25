using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    public GameObject myAvatar;
    public GameObject mainCamera;
    private PhotonView _PV;
    private GameObject _photonAvatar;
    private GameObject _empty;


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
        gameObject.GetComponent<TurnOffPlayerControl>().character = _photonAvatar;

    }
}