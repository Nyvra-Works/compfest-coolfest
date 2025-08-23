using StateMachines.Player.States;
using UnityEngine;

public class MB_AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private MB_PlayerStateContext _playerStateContext;
    [SerializeField] private MB_Facing _facing;
    private string _currentState;
    void OnEnable()
    {
        _playerStateContext.SetAnimationDirectionHandler += SetDirection;
        _playerStateContext.OnUpdateStateHandler += AnimationChange;
    }
    void OnDisable()
    {
        _playerStateContext.SetAnimationDirectionHandler -= SetDirection;
        _playerStateContext.OnUpdateStateHandler -= AnimationChange;
    }


    public void SetDirection(Vector3 dir)
    {
        var (side, forward, backward) = _facing.SetDirection(dir);
    }

    void AnimationChange(StateEnum state)
    {
        if (state == StateEnum.IdleState)
        {
            if (_facing.LastDir == Vector3.forward)
            {
                // _animator.Play(AnimationState.Idle_Forward);
                ChangeAnimationState(AnimationState.Idle_Forward);
            }
            else if (_facing.LastDir == Vector3.back)
            {
                // _animator.Play(AnimationState.Idle_Backward);
                ChangeAnimationState(AnimationState.Idle_Backward);
            }else
            {
                ChangeAnimationState(AnimationState.Idle_Backward);
            }
        }

        if (state == StateEnum.MovingState)
        {
            var (side, forward, backward) = _facing.SetDirection(Input.GetAxisRaw("Horizontal") * Vector3.right + Input.GetAxisRaw("Vertical") * Vector3.forward);
            if (side)
            {
                // _animator.Play(AnimationState.Walk_Side);
                ChangeAnimationState(AnimationState.Walk_Side);
                _spriteRenderer.flipX = _facing.LastDir.x < 0;
            }
            else if (forward)
            {
                // _animator.Play(AnimationState.Walk_Up);
                ChangeAnimationState(AnimationState.Walk_Up);
            }
            else if (backward)
            {
                // _animator.Play(AnimationState.Walk_Down);
                ChangeAnimationState(AnimationState.Walk_Down);
            }
        }
    }
    
    void ChangeAnimationState(string newState)
    {
        if (_currentState == newState) return;

        _animator.Play(newState);

        _currentState = newState;
    }



}
