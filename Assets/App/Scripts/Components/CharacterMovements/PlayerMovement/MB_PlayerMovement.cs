using StateMachines.Player.States;
using UnityEngine;

public class MB_PlayerMovement : MB_CharacterMovement
{
    // public override void FixedUpdate()
    // {
    //     // dont do anything
    // }
    // do here instead; update controlled by state machine

    [SerializeField] MB_PlayerStateContext _stateContext;
    void OnEnable()
    {
        _stateContext.OnUpdateStateHandler += UpdateInState;
    }
    public void UpdateInState(StateEnum stateMachineState)
    {
        // base.FixedUpdate();
        if (stateMachineState != StateEnum.MovingState)
        {
            return;
        }
        _locomotory.SetPosition(_characterControl.TargetDirection);

    }
    public void UpdateInState()
    {
        _locomotory.SetPosition(_characterControl.TargetDirection);

    }
}