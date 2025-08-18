using UnityEngine;

public class MB_AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private MB_PlayerStateContext _playerStateContext;
    [SerializeField] private MB_Facing _facing;

    void OnEnable()
    {
        _playerStateContext.SetAnimationDirectionHandler += SetDirection;
        _playerStateContext.IsMovingHandler += SetMoveAnimation;
    }

    public void SetMoveAnimation(bool isMoving)
    {
        _animator.SetBool("isMoving", isMoving);
    }

    public void SetDirection(Vector3 dir)
    {
        var (side, forward, backward) = _facing.SetDirection(dir);

        if (side)
                _spriteRenderer.flipX = (_facing.LastDir.x < 0);
        _animator.SetBool("faceSide", side);
        _animator.SetBool("faceForward", forward);
        _animator.SetBool("faceBackward", backward);
    }

    public void SetAimDirection(Vector3 aimWorldPos)
    {
        Vector3 dir = aimWorldPos - transform.position;
        SetDirection(dir);
    }
}
