using System;
using StateMachines.Player.States;
using UnityEngine;

public class MB_PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatReference _maximumHeight;
    public FloatReference MaximumHeight => _maximumHeight;

    [SerializeField] private FloatReference _speed;
    public FloatReference Speed => _speed;

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
        _stateContext.OnEnterJumpHandler += Jump;
    }
    void OnDisable()
    {
        if (_stateContext == null)
        {
            Debug.LogError($"{this.name} State Context is not assigned. Please assign a valid MB_PlayerStateContext.");
            return;
        }

        _stateContext.OnEnterJumpHandler -= Jump;
    }
    void Start()
    {
        if (_rigidbody == null)
        {
            Debug.LogError($"{this.name} Rigidbody is not assigned. Please assign a Rigidbody component.");
            return;
        }
    }
    public void Jump()
    {
        targetPosition = _rigidbody.position + Vector3.up * _maximumHeight.Value;
        float forceMagnitude = _rigidbody.mass * (float)Math.Sqrt(2 * Physics.gravity.magnitude * _maximumHeight.Value);
        _rigidbody.AddForce(Vector3.up * forceMagnitude, ForceMode.Impulse);
    }
}