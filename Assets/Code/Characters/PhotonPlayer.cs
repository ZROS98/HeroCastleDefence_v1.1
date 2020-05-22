using Photon.Pun;
using System.Collections;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    public GameObject mainCamera;
    private PhotonView _PV;
    public GameObject SliderButton;
    private GameObject _currentCharacter;

    public void SynchronizationSomeVariable()
    {
        Hashtable hash = new Hashtable();
        hash.Add("someVariable", "oooooooooo");
        PhotonNetwork.SetPlayerCustomProperties(hash);
    }

    public void Start()
    {
        //SynchronizationSomeVariable();
        //var anoutherCharacter = PhotonNetwork.PlayerListOthers[0].CustomProperties["someVariable"];

        _PV = gameObject.GetComponent<PhotonView>();
        _PV.RPC("SpawnCharacter", RpcTarget.AllBuffered);


        }

    [PunRPC]
    private void SpawnCharacter() //do it once
    {

            _currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
            new Vector3(25, 1, 85), Quaternion.identity);


            _currentCharacter.GetComponent<Movement>().chrCamera = mainCamera;
            gameObject.GetComponent<TurnOffPlayerControl>().charactersArray.Add(_currentCharacter);
            //_currentCharacter.GetComponent<CharacterInfo>().SliderButton = SliderButton;
    }
    
}