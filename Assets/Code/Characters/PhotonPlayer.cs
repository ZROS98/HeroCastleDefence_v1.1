using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    public GameObject myAvatar;
    public GameObject mainCamera;
    //private PhotonView _PV;
    private GameObject _photonAvatar;

    void Start()
    {
        myAvatar = SelectedCharacter.Prefab;
       
        //_PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        //if (_PV.IsMine)
        {
            _photonAvatar = PhotonNetwork.Instantiate(myAvatar.name,
                GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
        }
        _photonAvatar.GetComponent<Movement>().chrCamera = mainCamera;
        gameObject.GetComponent<TurnOffPlayerControl>().character = _photonAvatar;
    }
}
