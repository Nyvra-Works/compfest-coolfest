using UnityEngine;

public class MB_PlayerMovement : MB_CharacterMovement
{
    public override void Update()
    {
        // dont do anything
    }
    // do here instead; update controlled by state machine
    public void UpdateInState()
    {
        base.Update();
    }
}