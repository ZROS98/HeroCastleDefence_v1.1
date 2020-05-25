using Photon.Pun;
using UnityEngine;
using Cinemachine;

public class CharacterCreation : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView _PV;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;
    private GameObject _currentCharacter;
    private const int ChildIndexNumber_Holder_ThirdPersonCamera = 2;

    public void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _PV.RPC("SpawnCharacter", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void SpawnCharacter() //do it once
    {
        Transform spawnPoint = (PhotonNetwork.IsMasterClient ? _spawnPoints[0] : _spawnPoints[1]);

        _currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
        spawnPoint.position, Quaternion.identity);


        ThirdPersonMovement thirdPersonMovement = _currentCharacter.GetComponent<ThirdPersonMovement>();
        thirdPersonMovement.mainCameraTransform = _mainCameraTransform;
        thirdPersonMovement.cinemachineFreeLook = _cinemachineFreeLook;
    }

}