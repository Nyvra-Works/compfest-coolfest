using UnityEngine;

namespace StateMachines.Player.States
{
    public class HeadbuttAttackState : AbstractState<MB_PlayerStateContext>
    {
        public override void Enter(MB_PlayerStateContext context)
        {
            Debug.Log("Entering Headbutt Attack State");
        }

        public override void Exit(MB_PlayerStateContext context)
        {
            Debug.Log("Exiting Headbutt Attack State");
        }

        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            if (context.CollisionTargetFinder.Targets.Count > 0)
            {
                context.TransitionToState(StateEnum.IdleState);
            }
        }
    }
}