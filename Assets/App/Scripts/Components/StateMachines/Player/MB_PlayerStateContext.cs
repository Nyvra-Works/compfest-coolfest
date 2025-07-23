using System.Collections.Generic;
using StateMachines.Player.States;
using UnityEngine;

public class MB_PlayerStateContext : MB_AbstractContext<StateEnum>
{
    [SerializeField] private StateEnum _initialState = StateEnum.IdleState;
    [Space]
    [Header("# Movement\n=================================================================")]
    [Space]
    [SerializeField] private MB_CharacterMovement characterMovement;
    [SerializeField] private MB_CharacterMovementControl characterMovementControl;
    public MB_CharacterMovement CharacterMovement => characterMovement;
    public MB_CharacterMovementControl CharacterMovementControl => characterMovementControl;

    [Space]
    [Header("# Combat\n==================================================================")]
    [Space]
    [SerializeField] private MB_CombatInput combatInput;
    [SerializeField] private MB_PlayerAlphaCombatController combatController;
    [SerializeField] private FloatReference basicAttackSpeed;
    public MB_CombatInput CombatInput => combatInput;
    public MB_PlayerAlphaCombatController CombatController => combatController;
    public FloatReference BasicAttackSpeed => basicAttackSpeed;
    public AbstractState<MB_PlayerStateContext> currentState { get; set; }


    [Header("## Collision Checker\n==================================================================")]
    [SerializeField] private MB_TargetFinder groundTargetFinder;
    public MB_TargetFinder GroundTargetFinder => groundTargetFinder;

    [SerializeField] private MB_TargetFinder headButtTargetFinder;
    public MB_TargetFinder HeadButtTargetFinder => headButtTargetFinder;

    /// <summary>
    /// States of the machine, keyed with their respective StateEnum.
    /// </summary>
    /// <returns></returns>
    public Dictionary<StateEnum, AbstractState<MB_PlayerStateContext>> States { get; protected set; } = new()
    {
        { StateEnum.IdleState, new IdleState() },
        { StateEnum.MovingState, new MovingState() },
        { StateEnum.BasicAttackState, new BasicAttackState() },
        { StateEnum.HeadbuttAttackAscendingState, new HeadbuttAttackAscendingState() },
        { StateEnum.HeadbuttAttackDescendingState, new HeadbuttAttackDescendingState() },
    };

    /// 
    private void Start()
    {
        // Initialize the state machine with the Idle state
        TransitionToState(_initialState);

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