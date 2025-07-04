using System.Collections.Generic;
using StateMachines.Player.States;
using UnityEngine;

public class MB_PlayerStateContext : MB_AbstractContext<StateEnum>
{
    AbstractState<MB_AbstractContext<StateEnum>, StateEnum> _currentState = null;
    // public IdleState IdleState { get; private set; } = new IdleState();
    public override Dictionary<StateEnum, AbstractState<MB_AbstractContext<StateEnum>, StateEnum>> States { get; protected set; } = new Dictionary<StateEnum, AbstractState<MB_AbstractContext<StateEnum>, StateEnum>>()
    {
        { StateEnum.IdleState, new IdleState() },
        { StateEnum.MovingState, new MovingState() },
    };
    private void Start()
    {
        // Initialize the state machine with the Idle state
        TransitionToState(StateEnum.IdleState);

    }
    private void Update()
    {
        // Update the current state
        _currentState?.UpdateExecute(this);
    }
    public override void TransitionToState(StateEnum newState)
    {
        // Exit the current state if it exists
        _currentState?.Exit(this);

        // Set the new state
        _currentState = States[newState];

        // Enter the new state
        _currentState.Enter(this);
    }
}