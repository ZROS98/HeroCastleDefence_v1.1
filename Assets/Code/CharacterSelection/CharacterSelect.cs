﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviourPunCallbacks
{
    public GameObject prefabSelectedCharacter;

    public void ChangeSelectedCharacter(GameObject character)
    {
        prefabSelectedCharacter = character;
    }


    public void LoadArena()
    {
        PhotonView _PV = gameObject.GetComponent<PhotonView>();
        _PV.RPC("LoadArenaRPC", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void LoadArenaRPC()
    {
        SelectedCharacter.Prefab = prefabSelectedCharacter;
        SceneManager.LoadScene(2);
    }

}
