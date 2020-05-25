using Photon.Pun;
using UnityEngine;

public class CharacterCreation : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView _PV;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private Cinemachine.CinemachineFreeLook _cinemachineFreeLook;
    private GameObject _currentCharacter;
    private const int ChildIndexNumber_Holder_ThirdPersonCamera = 2;

    public void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _PV.RPC("SpawnCharacter", RpcTarget.AllBuffered);
        }
        _cinemachineFreeLook.LookAt = _currentCharacter.transform.GetChild(ChildIndexNumber_Holder_ThirdPersonCamera).transform;
        _cinemachineFreeLook.Follow = _currentCharacter.transform.GetChild(ChildIndexNumber_Holder_ThirdPersonCamera).transform;
    }

    [PunRPC]
    private void SpawnCharacter() //do it once
    {
        Transform spawnPoint = (PhotonNetwork.IsMasterClient ? _spawnPoints[0] : _spawnPoints[1]);

        _currentCharacter = PhotonNetwork.Instantiate(SelectedCharacter.Prefab.name,
        spawnPoint.position, Quaternion.identity);





        _currentCharacter.GetComponent<ThirdPersonMovement>().mainCameraTransform = _mainCameraTransform;
    }

}