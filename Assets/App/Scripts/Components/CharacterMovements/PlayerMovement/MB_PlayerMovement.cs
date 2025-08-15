using UnityEngine;

public class MB_PlayerMovement : MB_CharacterMovement
{
    // public override void FixedUpdate()
    // {
    //     // dont do anything
    // }
    // do here instead; update controlled by state machine
    public void UpdateInState()
    {
        // base.FixedUpdate();
        _locomotory.SetPosition(_characterControl.TargetDirection);

    }
}