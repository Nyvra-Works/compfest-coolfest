using System;
using StateMachines.Enemy.States;
using UnityEngine;

public class MB_EnemyStateContext : MonoBehaviour
{
    private BaseState _currentState;
    public PursuingState PursuingState { get; private set; } = new PursuingState();
    public IdleState IdleState { get; private set; } = new IdleState();
    public AttackingState AttackingState { get; private set; } = new AttackingState();

    public Action OnAttackingEnter;
    public Action OnAttackingExit;


    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderByLayer { get; private set; }
    // [field: SerializeField] public MB_CharacterMovement CharacterMovement { get; private set; }

    [Header("Attacking State")]
    [field: SerializeField] public float StoppingDistance { get; private set; } = 2;

    private void Start()
    {
        // Initialize the state machine with the Idle state
        TransitionToState(IdleState);

    }
    private void Update()
    {
        // Update the current state
        _currentState?.UpdateExecute(this);
    }
    public void TransitionToState(BaseState newState)
    {
        // Exit the current state if it exists
        _currentState?.Exit(this);

        // Set the new state
        _currentState = newState;

        // Enter the new state
        _currentState.Enter(this);
    }
}