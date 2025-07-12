using System;
using StateMachines.Enemy.States;
using UnityEngine;

public class MB_EnemyStateContext : MonoBehaviour
{
    private BaseState _currentState;
    public PursuingState PursuingState { get; private set; } = new PursuingState();
    public IdleState IdleState { get; private set; } = new IdleState();
    public AttackingState AttackingState { get; private set; } = new AttackingState();
    public SoaringState SoaringState { get; private set; } = new SoaringState();

    // public Action OnAttackingEnter;
    // public Action OnAttackingExit;

    [Header("Targets")]
    [SerializeField] MB_TargetsFinderByLayer _targetsFinderByLayer;
    public MB_TargetsFinderByLayer TargetsFinderByLayer => _targetsFinderByLayer;
    [Header("Ground Checker")]
    [SerializeField] MB_CollisionTargetFinderByLayer _collisionTargetFinderByLayer;
    public MB_CollisionTargetFinderByLayer CollisionTargetFinderByLayer => _collisionTargetFinderByLayer;
    // [field: SerializeField] public MB_CharacterMovement CharacterMovement { get; private set; }

    [Header("Movement")]
    [SerializeField] MB_EnemyMovement movement;
    public MB_EnemyMovement Movement => movement;
    [Header("Attacking State")]
    [SerializeField] float stoppingDistance = 2;
    public float StoppingDistance => stoppingDistance;

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
    private void FixedUpdate()
    {
        _currentState?.FixedUpdateExecute(this);
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