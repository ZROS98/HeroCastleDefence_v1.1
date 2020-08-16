using Photon.Pun;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CharacterCreationOffline : MonoBehaviourPunCallbacks
{
    [SerializeField] private Slider _slider;

    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;

    private GameObject _currentCharacter;

    public void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        Transform spawnPoint = _spawnPoints[0];

        GameObject characterObj = Resources.Load("Chr_Warrior") as GameObject;
        _currentCharacter = Instantiate(characterObj,
            spawnPoint.position, Quaternion.identity);

        CurrentCharacter.currentCharacter = _currentCharacter;

        ThirdPersonMovement thirdPersonMovement = _currentCharacter.GetComponent<ThirdPersonMovement>();
        thirdPersonMovement.mainCameraTransform = _mainCameraTransform;
        thirdPersonMovement.cinemachineFreeLook = _cinemachineFreeLook;
        thirdPersonMovement.enabled = true;

        CharacterRespawnDeathController characterRespawnDeathController =
            _currentCharacter.GetComponent<CharacterRespawnDeathController>();
        characterRespawnDeathController.spawnPoint = spawnPoint;

        ChangeSliderHealthBar healthBar = _currentCharacter.GetComponent<ChangeSliderHealthBar>();
        healthBar.slider = _slider;

        AimCharacterToMob aimCharacterToMob = _currentCharacter.GetComponent<AimCharacterToMob>();
        aimCharacterToMob.cinemachineFreeLook = _cinemachineFreeLook;
        aimCharacterToMob.enabled = true;

        ShopInteraction shopInteraction = _currentCharacter.GetComponent<ShopInteraction>();
        shopInteraction.cinemachineFreeLook = _cinemachineFreeLook;
        shopInteraction.enabled = true;
    }
}