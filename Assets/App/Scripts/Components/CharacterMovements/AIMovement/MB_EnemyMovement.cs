using StateMachines.Enemy.States;
using UnityEngine;

public class MB_EnemyMovement : MB_CharacterMovement
{

    public void UpdateInState()
    {
        // base.FixedUpdate();
        _locomotory.SetPosition(_characterControl.TargetDirection);

    }
}