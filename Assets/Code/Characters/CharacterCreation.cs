using Photon.Pun;
using UnityEngine;
using Cinemachine;

public class CharacterCreation : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;
    private GameObject _currentCharacter;

    public void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _photonView.RPC("SpawnCharacter", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void SpawnCharacter()
    {
        Transform spawnPoint = (PhotonNetwork.IsMasterClient ? _spawnPoints[0] : _spawnPoints[1]);

        _currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
        spawnPoint.position, Quaternion.identity);


        ThirdPersonMovement thirdPersonMovement = _currentCharacter.GetComponent<ThirdPersonMovement>();
        thirdPersonMovement.mainCameraTransform = _mainCameraTransform;
        thirdPersonMovement.cinemachineFreeLook = _cinemachineFreeLook;
        MobCreation mobCreation = gameObject.GetComponent<MobCreation>();
        mobCreation.targetCharacter = _currentCharacter;
    }

}