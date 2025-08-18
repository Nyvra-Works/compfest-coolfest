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
    private Vector3 _velocity;
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
        _velocity = new(direction.normalized.x * _walkSpeed * Time.fixedDeltaTime, _rigidbody.linearVelocity.y, direction.normalized.z * _walkSpeed * Time.fixedDeltaTime);
        _rigidbody.linearVelocity = _velocity;
    }
}