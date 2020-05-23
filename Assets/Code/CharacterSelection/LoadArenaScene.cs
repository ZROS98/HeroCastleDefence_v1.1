using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArenaScene : MonoBehaviour
{
    public float secondsToCreation;
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

            yield return new WaitForSeconds(secondsToCreation);
            LoadArena();
        }
    }

    private bool BothPlayersIsReady()
    {
        Debug.Log("thisPlayerIsReady =" + PhotonNetwork.LocalPlayer.CustomProperties["PlayerIsReadyProperties"]);
        bool thisPlayerIsReady = (bool) PhotonNetwork.LocalPlayer.CustomProperties["PlayerIsReadyProperties"];
        bool enemyPlayerIsReady = false;

        if (PhotonNetwork.PlayerList.Length > 1)
        {
            Debug.Log("enemyPlayerIsReady =" + PhotonNetwork.PlayerListOthers[0].CustomProperties["PlayerIsReadyProperties"]);
            enemyPlayerIsReady = (bool) PhotonNetwork.PlayerListOthers[0].CustomProperties["PlayerIsReadyProperties"];
        }
        else
        {
            Debug.Log("Second player does not exist");
            enemyPlayerIsReady = false;
            LoadArena();
        }


        if (enemyPlayerIsReady == true && thisPlayerIsReady == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
