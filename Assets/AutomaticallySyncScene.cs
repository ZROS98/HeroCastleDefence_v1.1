using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticallySyncScene : MonoBehaviour
{

    public void ChangeSyncScene()
    {
        PhotonNetwork.AutomaticallySyncScene = !PhotonNetwork.AutomaticallySyncScene;
    }
}
