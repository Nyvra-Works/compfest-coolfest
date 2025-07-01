using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class IdleState : BaseState
    {
        public override void Enter(EnemyStateContext context)
        {
            Debug.Log("Entering Idle State");
        }

        public override void UpdateExecute(EnemyStateContext context)
        {
            if (context.TargetsFinderByLayer.Targets.Count > 0)
            {
                context.TransitionToState(context.PursuingState);
            }
        }

        public override void Exit(EnemyStateContext context)
        {
            // Logic for exiting the idle state
        }
    }
}