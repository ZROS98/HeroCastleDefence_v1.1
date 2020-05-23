using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArenaScene : MonoBehaviour
{
    [SerializeField] private float _secondsToCreation;

    public void CreateCharacter()
    {
        StartCoroutine(Timer());
    }

    private void LoadArena()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (_bothPlayersIsReady())
            {
                LoadArena();
            }

            yield return new WaitForSeconds(_secondsToCreation);
            LoadArena();
        }
    }

    private bool _bothPlayersIsReady()
    {
        var thisPlayerIsReady = PhotonNetwork.LocalPlayer.CustomProperties["PlayerIsReady"];

        var enemyPlayerIsReady = new object();
        if (PhotonNetwork.PlayerList.Length > 1)
        {
            enemyPlayerIsReady = PhotonNetwork.PlayerListOthers[0].CustomProperties["PlayerIsReady"];
        }
        else
        {
            enemyPlayerIsReady = false;
            Debug.Log("Second player does not exist");
        }


        if (thisPlayerIsReady == enemyPlayerIsReady == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
