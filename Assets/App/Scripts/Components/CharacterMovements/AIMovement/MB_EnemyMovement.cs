using StateMachines.Enemy.States;
using UnityEngine;

public class MB_EnemyMovement : MB_CharacterMovement
{
    // public override void FixedUpdate()
    // {

    //     // if (!_overrideStopWalk)
    //     // {
    //     //     _walkable.SetPosition(_characterControl.TargetDirection);
    //     // }
    //     // else
    //     // {
    //     //     _walkable.SetPosition(Vector3.zero);
    //     // }
    //     // Debug.Log($"Target Direction: {_characterControl.TargetDirection}");
    // }

    public void UpdateInState()
    {
        // base.FixedUpdate();
        _walkable.SetPosition(_characterControl.TargetDirection);

    }
}