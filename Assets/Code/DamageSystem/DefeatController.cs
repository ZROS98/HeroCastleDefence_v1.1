using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatController : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    private bool _gameOver = false;

    public void Loss()
    {
        if (!_gameOver)
        {
            Debug.Log("You loss");
            _gameOver = true;
            _photonView.RPC("Win", RpcTarget.Others);
        }
    }

    [PunRPC]
    public void Win()
    {
        Debug.Log("You win");
        _gameOver = true;
    }
}
