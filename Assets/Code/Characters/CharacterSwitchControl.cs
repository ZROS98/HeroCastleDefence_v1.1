using Cinemachine;
using UnityEngine;

public class CharacterSwitchControl : MonoBehaviour
{
    private ThirdPersonMovement _thirdPersonMovement;
    private CinemachineBrain _cinemachineBrain;
    private CharacterAttack _characterAttack;

    public static CharacterSwitchControl current;

    private void Start()
    {
        current = this;

        GameObject character = CurrentCharacter.currentCharacter;
        _thirdPersonMovement = character.GetComponent<ThirdPersonMovement>();
        _characterAttack = character.GetComponent<CharacterAttack>();

        _cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
    }

    public void CharacterControlTurnOff()
    {
        _thirdPersonMovement.SetStopMovement(true);
        _characterAttack.enabled = false;
        _cinemachineBrain.enabled = false;
        Cursor.visible = true;
    }

    public void CharacterControlTurnOn()
    {
        _thirdPersonMovement.SetStopMovement(false);
        _characterAttack.enabled = true;
        _cinemachineBrain.enabled = true;
        Cursor.visible = false;
    }
}
