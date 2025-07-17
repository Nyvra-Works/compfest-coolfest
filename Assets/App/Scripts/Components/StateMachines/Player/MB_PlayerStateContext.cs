 using System.Collections.Generic;
using StateMachines.Player.States;
using UnityEngine;

public class MB_PlayerStateContext : MB_AbstractContext<StateEnum>
{
    [Header("# Movement\n=================================================================")]
    [SerializeField] private MB_CharacterMovement characterMovement;
    [SerializeField] private MB_CharacterMovementControl characterMovementControl;
    public MB_CharacterMovement CharacterMovement => characterMovement;
    public MB_CharacterMovementControl CharacterMovementControl => characterMovementControl;
    [Header("## Ground Checker\n==================================================================")]
    [SerializeField] private MB_CollisionTargetFinderByLayer groundChecker;
    public MB_CollisionTargetFinderByLayer CollisionTargetFinder => groundChecker;

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
    public Dictionary<StateEnum, AbstractState<MB_PlayerStateContext>> States { get; protected set; } = new()
    {
        { StateEnum.IdleState, new IdleState() },
        { StateEnum.MovingState, new MovingState() },
        { StateEnum.BasicAttackState, new BasicAttackState() },
        { StateEnum.HeadbuttAttackState, new HeadbuttAttackState() }
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