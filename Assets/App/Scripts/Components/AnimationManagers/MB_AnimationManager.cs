using UnityEngine;

public class MB_AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private MB_PlayerStateContext _playerStateContext;

    private Vector3 lastDir = Vector3.down;

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
        if (dir != Vector3.zero)
        {
            lastDir = dir;

            bool facingSide = Mathf.Abs(dir.x) > Mathf.Abs(dir.z);
            _animator.SetBool("faceSide", facingSide);
            _animator.SetBool("faceForward", dir.z > 0 && !facingSide);
            _animator.SetBool("faceBackward", dir.z < 0 && !facingSide);

            if (facingSide)
                _spriteRenderer.flipX = (dir.x < 0);
        }
    }

    public void SetAimDirection(Vector3 aimWorldPos)
    {
        Vector3 dir = aimWorldPos - transform.position;
        SetDirection(dir);
    }
}
