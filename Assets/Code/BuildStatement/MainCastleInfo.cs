using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCastleInfo : MonoBehaviour
{
    public int healthPoint = 100;

    private void Update()
    {
        if (healthPoint < 1)
        {
            //LoseSign();
            PhotonView.Get(this).RPC("WinSign", RpcTarget.Others);
        }
    }

    private void WinSign()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            healthPoint -= 10;
        }
    }
}
