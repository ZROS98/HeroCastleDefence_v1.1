using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArenaScene : MonoBehaviour
{
    [SerializeField] private float _secondsToCreation;
    [SerializeField] private PhotonView _photonView;

    public void CreateCharacter()
    {
        StartCoroutine(Timer());
    }

    private void LoadArena()
    {
        _photonView.RPC("LoadArenaRPC", RpcTarget.MasterClient);
    }

    [PunRPC]
    private void LoadArenaRPC()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        SceneManager.LoadScene(2);
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (BothPlayersIsReady())
            {
                LoadArena();
                
            }

            yield return new WaitForSeconds(_secondsToCreation);
            LoadArena();
        }
    }

    private bool BothPlayersIsReady()
    {
        bool thisPlayerIsReady = (bool) PhotonNetwork.LocalPlayer.CustomProperties["PlayerIsReady"];
        bool enemyPlayerIsReady;

        if (PhotonNetwork.PlayerList.Length > 1)
        {
            enemyPlayerIsReady = (bool) PhotonNetwork.PlayerListOthers[0].CustomProperties["PlayerIsReady"];
        }
        else
        {
            enemyPlayerIsReady = false;
            Debug.Log("Second player does not exist");
        }


        if (enemyPlayerIsReady==true && thisPlayerIsReady == true) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}