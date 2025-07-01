using System;
using UnityEngine;

public class MB_PlayerWalk : MB_CharacterWalk
{
    private Rigidbody _rigidbody;
    private float _walkSpeed;
    // public PlayerWalk(Rigidbody rigidbody, float walkSpeed)
    // {
    //     _rigidbody = rigidbody;
    //     _walkSpeed = walkSpeed;
    // }
    private Vector3 direction;
    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _walkSpeed = GetComponent<MB_CharacterMovement>().WalkSpeed;
    }
    public override void SetPosition(Vector3 direction)
    {
        this.direction = direction;
    }
    private void FixedUpdate()
    {
        Vector3 velocity = new(direction.normalized.x * _walkSpeed, _rigidbody.linearVelocity.y, direction.normalized.z * _walkSpeed);
        _rigidbody.linearVelocity = velocity;
    }
}