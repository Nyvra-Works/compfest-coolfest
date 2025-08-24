using System;
using StateMachines.Player.States;
using UnityEngine;

public class MB_StompMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatReference _force;

    [Header("State Machine Context")]
    [SerializeField] private MB_PlayerStateContext _stateContext;

    Vector3 targetPosition;

    void OnEnable()
    {
        if (_stateContext == null)
        {
            Debug.LogError($"{this.name} State Context is not assigned. Please assign a valid MB_PlayerStateContext.");
            return;
        }

        _stateContext.OnEnterStompAttackHandler += Stomp;

    }
    void OnDisable()
    {
        if (_stateContext == null)
        {
            Debug.LogError($"{this.name} State Context is not assigned. Please assign a valid MB_PlayerStateContext.");
            return;
        }

        _stateContext.OnEnterStompAttackHandler -= Stomp;

    }
    void Start()
    {
        if (_rigidbody == null)
        {
            Debug.LogError($"{this.name} Rigidbody is not assigned. Please assign a Rigidbody component.");
            return;
        }
    }
    public void Stomp()
    {
        // Implement stomp logic here
        // Example: Apply a downward force to the Rigidbody
        _rigidbody.AddForce(Vector3.down * _force.Value, ForceMode.Impulse);
    }
}