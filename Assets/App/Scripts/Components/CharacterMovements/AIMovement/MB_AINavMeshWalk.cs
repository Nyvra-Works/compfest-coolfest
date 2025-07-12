using System;
using UnityEngine;
using UnityEngine.AI;

public class MB_AINavMeshWalk : MB_CharacterWalk
{
    [SerializeField] NavMeshAgent _navMeshAgent;
    private Vector3 _targetDirection;
    private Rigidbody rb;
    private float _speed;
    
    void Start()
    {
        _navMeshAgent.updateRotation = false; // Disable automatic rotation to control rotation manually if needed   
        _navMeshAgent.updatePosition = false; // Disable automatic position to control rotation manually if needed   
        // _navMeshAgent.speed = GetComponent<MB_CharacterMovement>().WalkSpeed;
        _speed = GetComponent<MB_CharacterMovement>().WalkSpeed;

        rb = GetComponent<Rigidbody>();
    }
    public override void SetPosition(Vector3 direction)
    {
        _targetDirection = direction + transform.position;
        _navMeshAgent.SetDestination(_targetDirection);

        // modify only horizontal velocity
        // rb.linearVelocity = new Vector3(_navMeshAgent.velocity.x, rb.linearVelocity.y, _navMeshAgent.velocity.z);
        var velocity = (_navMeshAgent.pathEndPosition - transform.position) * _speed * Time.fixedDeltaTime;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }
}