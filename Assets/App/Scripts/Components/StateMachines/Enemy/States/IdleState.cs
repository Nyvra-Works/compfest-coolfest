using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class IdleState : BaseState
    {
        public override void Enter(MB_EnemyStateContext context)
        {
            // Debug.Log("Entering Idle State");
        }

        public override void UpdateExecute(MB_EnemyStateContext context)
        {
            if (context.TargetsFinderByLayer.Targets.Count > 0)
            {
                Debug.Log("MEAG");
                context.TransitionToState(context.PursuingState);
            }
        }

        public override void Exit(MB_EnemyStateContext context)
        {
            // Logic for exiting the idle state
        }
    }
}