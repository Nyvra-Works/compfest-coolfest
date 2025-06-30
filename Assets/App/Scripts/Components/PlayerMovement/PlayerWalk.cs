using UnityEngine;

public class PlayerWalk : IWalk
{
    private readonly Rigidbody _rigidbody;
    private readonly float _walkSpeed;
    public PlayerWalk(Rigidbody rigidbody, float walkSpeed)
    {
        _rigidbody = rigidbody;
        _walkSpeed = walkSpeed;
    }
    public void Move(Vector3 direction)
    {
        Vector3 velocity = new(direction.normalized.x * _walkSpeed, _rigidbody.linearVelocity.y, direction.normalized.z * _walkSpeed);
        _rigidbody.linearVelocity = velocity;
    }
}