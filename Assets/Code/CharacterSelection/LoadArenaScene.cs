using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArenaScene : MonoBehaviour
{
    public void LoadArena()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }
}
