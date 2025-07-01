using System;
using UnityEngine;
using UnityEngine.AI;

public class MB_AINavMeshWalk : MB_CharacterWalk
{
    [SerializeField] NavMeshAgent _navMeshAgent;
    private Vector3 _targetDirection;
    void Start()
    {
        _navMeshAgent.updateRotation = false; // Disable automatic rotation to control rotation manually if needed   
        _navMeshAgent.speed = GetComponent<MB_CharacterMovement>().WalkSpeed;
    }
    public override void SetPosition(Vector3 direction)
    {
        _targetDirection = direction+transform.position;
        _navMeshAgent.SetDestination(_targetDirection);
    }
}