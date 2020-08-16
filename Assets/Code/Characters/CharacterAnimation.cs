using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void ChangeAttackSpeed(float newAttackSpeed)
    {
        _animator.SetFloat("attackSpeed", newAttackSpeed);
    }

    public void ChangeMoveSpeed(float newMoveSpeed)
    {
        _animator.SetFloat("moveSpeed", newMoveSpeed);
    }

    public void SetIsMoving(bool isMoving)
    {
        _animator.SetBool("isMoving", isMoving);
    }

    public void SetIsDead(bool isDead)
    {
        _animator.SetBool("IsDead", isDead);
    }

    public void SetIsAttacking()
    {
        _animator.SetTrigger("isAttacking");
    }
}
