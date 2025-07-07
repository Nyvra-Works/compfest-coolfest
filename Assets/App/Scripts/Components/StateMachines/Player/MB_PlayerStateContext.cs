using System.Collections.Generic;
using StateMachines.Player.States;
using UnityEngine;

public class MB_PlayerStateContext : MB_AbstractContext<StateEnum>
{
    [Header("Movement")]
    [field: SerializeField] public MB_CharacterMovement CharacterMovement { get; private set; }
    [field: SerializeField] public MB_CharacterMovementControl CharacterMovementControl { get; private set; }

    [Header("Combat")]
    [field: SerializeField] public MB_CombatInput CombatInput { get; private set; }
    [field: SerializeField] public MB_PlayerAlphaCombatController CombatController { get; private set; }
    
    public AbstractState<MB_PlayerStateContext> currentState { get; set; }
    public Dictionary<StateEnum, AbstractState<MB_PlayerStateContext>> States { get; protected set; } = new()
    {
        { StateEnum.IdleState, new IdleState() },
        { StateEnum.MovingState, new MovingState() },
        { StateEnum.BasicAttackState, new BasicAttackState() }
    };

    /// 
    private void Start()
    {
        // Initialize the state machine with the Idle state
        TransitionToState(StateEnum.IdleState);

    }
    private void Update()
    {
        // Update the current state
        currentState?.UpdateExecute(this);
    }
    public override void TransitionToState(StateEnum newState)
    {
        // Exit the current state if it exists
        currentState?.Exit(this);

        // Set the new state
        currentState = States[newState];

        // Enter the new state
        currentState.Enter(this);
    }
}