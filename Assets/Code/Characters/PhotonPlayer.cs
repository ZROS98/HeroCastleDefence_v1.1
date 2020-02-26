using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    private PhotonView PV;

    public GameObject myAvatar;
    public GameObject mainCamera;
    private GameObject photonAvatar;

    void Start()
    {
        myAvatar = SelectedCharacter.Prefab;
        PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        if (PV.IsMine)
        {
             photonAvatar = PhotonNetwork.Instantiate(myAvatar.name,
                GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
        }
        photonAvatar.GetComponent<Movement>().chrCamera = mainCamera;
    }
}
