using Photon.Pun;
using UnityEngine;

public class CharacterCreation : MonoBehaviourPunCallbacks
{
    private PhotonView _PV;
    [SerializeField] private Transform[] _spawnPoints;



    public GameObject mainCamera;
//    public GameObject SliderButton;

    public void Start()
    {
        _PV = gameObject.GetComponent<PhotonView>();
        _PV.RPC("SpawnCharacter", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void SpawnCharacter() //do it once
    {
        Transform spawnPoint = (PhotonNetwork.IsMasterClient ? _spawnPoints[0] : _spawnPoints[1]);

        GameObject _currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
        spawnPoint.position, Quaternion.identity);





        _currentCharacter.GetComponent<Movement>().chrCamera = mainCamera;
        //gameObject.GetComponent<TurnOffPlayerControl>().charactersArray.Add(_currentCharacter);
        //_currentCharacter.GetComponent<CharacterInfo>().SliderButton = SliderButton;
    }

}