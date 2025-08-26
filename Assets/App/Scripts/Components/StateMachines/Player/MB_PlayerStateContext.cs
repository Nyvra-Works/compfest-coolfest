using System;
using System.Collections.Generic;
using StateMachines.Player.States;
using StateMachines;
using UnityEngine;

public class MB_PlayerStateContext : MB_AbstractStateContext<StateEnum, MB_PlayerStateContext>
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


    [Header("## Collision Checker\n==================================================================")]
    [SerializeField] private MB_TargetFinder groundTargetFinder;
    public MB_TargetFinder GroundTargetFinder => groundTargetFinder;

    [SerializeField] private MB_TargetFinder headButtTargetFinder;
    public MB_TargetFinder HeadButtTargetFinder => headButtTargetFinder;


    public Rigidbody Rigidbody{ get; set; }

    // Delegates definition =========================================================================
    public Action HeadbuttJumpHandler;
    public Action HeadbuttStayAscendingHandler;

    public Action OnEnterJumpHandler;

    public Action OnEnterStompAttackHandler;
    public Action OnExitStompAttackHandler;

    public Action<Vector3> SetAnimationDirectionHandler;

    public Action<StateEnum> OnEnterStateHandler;
    public Action<StateEnum> OnUpdateStateHandler;
    public Action<StateEnum> OnExitStateHandler;


    /// <summary>
    /// States of the machine, keyed with their respective StateEnum.
    /// </summary>
    /// <returns></returns>
    public override Dictionary<StateEnum, AbstractState<MB_PlayerStateContext>> StateMap { get; } = new()
    {
        { StateEnum.IdleState, new IdleState() },
        { StateEnum.MovingState, new MovingState() },
        { StateEnum.BasicAttackState, new BasicAttackState() },
        { StateEnum.HeadbuttAttackAscendingState, new HeadbuttAttackAscendingState() },
        { StateEnum.HeadbuttAttackDescendingState, new HeadbuttAttackDescendingState() },
        { StateEnum.JumpAscendingState, new JumpAscendingState() },
        { StateEnum.JumpDescendingState, new JumpDescendingState() },
        {StateEnum.StompAttackState, new StompAttackState() }
    };


    /// 
    private void Start()
    {
        // Initialize the state machine with the Idle state
        TransitionToState(_initialState);
        Rigidbody = GetComponent<Rigidbody>();
        if (headButtTargetFinder == null)
        {
            Debug.LogError("HeadButtTargetFinder is not assigned. Please assign a HeadButtTargetFinder component.");
        }

    }
    // public override void TransitionToState(StateEnum newState)
    // {
    //     // Exit the current state if it exists
    //     currentState?.Exit(this);

    //     // Set the new state
    //     currentState = StateMap[newState];

    //     // Enter the new state
    //     currentState.Enter(this);
    // }
}