using Photon.Pun;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerIsReady : MonoBehaviour
{
    private Hashtable _hash = new Hashtable();

    void Start()
    {
        _hash.Add("PlayerIsReady", false);
        PhotonNetwork.SetPlayerCustomProperties(_hash);
    }

    public void SetPlayerIsReadyPropertiesTrue()
    {
        _hash["PlayerIsReady"] = true;
        PhotonNetwork.SetPlayerCustomProperties(_hash);
    }
}
