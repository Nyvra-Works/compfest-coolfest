using StateMachines.Player.States;
using UnityEngine;
using StateMachines;

public class HeadbuttAttackDescendingState : AbstractState<MB_PlayerStateContext>
{
    public override void Enter(MB_PlayerStateContext context)
    {
        Debug.Log("Entering Headbutt Attack Descending State");
    }

    public override void Exit(MB_PlayerStateContext context)
    {
        Debug.Log("Exiting Headbutt Attack Descending State");
    }

    public override void UpdateExecute(MB_PlayerStateContext context)
    {
        if (context.GroundTargetFinder.HasTargets())
        {
            context.TransitionToState(StateEnum.IdleState);
        }
    }
}