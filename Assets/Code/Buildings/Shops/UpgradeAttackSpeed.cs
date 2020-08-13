using UnityEngine;

public class UpgradeAttackSpeed : MonoBehaviour
{
    private const float speedValueStep = 1; 
    [HideInInspector] public Animator animator;  
    [HideInInspector] public CharacterStatsInfo characterStatsInfo;
    
    public void IncreaseAttackSpeed()
    {
        float currentAttackSpeed = characterStatsInfo.GetAttackSpeed();
        float newAttackSpeed = currentAttackSpeed + speedValueStep;
        
        animator.SetFloat("AttackSpeed", newAttackSpeed);
        characterStatsInfo.SetAttackSpeed(newAttackSpeed);
    }

    private void Start()
    {
        animator = CurrentCharacter.currentCharacter.GetComponent<Animator>();
        characterStatsInfo = CurrentCharacter.currentCharacter.GetComponent<CharacterStatsInfo>();
    }
}
