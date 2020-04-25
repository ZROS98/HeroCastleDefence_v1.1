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
        _PV.RPC("CubeSpawn", RpcTarget.AllBuffered);

    }
    [PunRPC]
    private void CubeSpawn()
    {
        _empty = PhotonNetwork.Instantiate("Empty",
            new Vector3(20, 1, 70), gameObject.transform.rotation, 0);

        GameObject currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name, _empty.transform.position, _empty.transform.rotation);
        currentCharacter.transform.SetParent(_empty.transform);

    }
    /* void Start()
     {
         myAvatar = SelectedCharacter.Prefab;
         _PV = GetComponent<PhotonView>();
         int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
         if (_PV.IsMine)
         {
             _photonAvatar = PhotonNetwork.Instantiate(myAvatar.name,
                 GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
         }
         _photonAvatar.GetComponent<Movement>().chrCamera = mainCamera;
         gameObject.GetComponent<TurnOffPlayerControl>().character = _photonAvatar;
     }*/
}