using UnityEngine;

namespace StateMachines.Player.States
{
    public class HeadbuttAttackAscendingState : AbstractState<MB_PlayerStateContext>
    {
        public override void Enter(MB_PlayerStateContext context)
        {
            Debug.Log("Entering Headbutt Attack Ascending State");
        }

        public override void Exit(MB_PlayerStateContext context)
        {
            Debug.Log("Exiting Headbutt Attack Ascending State");
        }

        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            if (context.HeadButtTargetFinder.HasTargets())
            {
                Debug.Log("I just headbutt something valid, transitioning to descending state.", context.gameObject);
                context.TransitionToState(StateEnum.HeadbuttAttackDescendingState);
            }
        }
    }
}