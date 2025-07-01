using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class PursuingState: BaseState
    {
        public override void Enter(EnemyStateContext context)
        {
            Debug.Log("Entering Pursuing State");
        }

        public override void UpdateExecute(EnemyStateContext context)
        {
            if (context.TargetsFinderByLayer.Targets.Count == 0)
            {
                context.TransitionToState(context.IdleState);
            }
            if (context.TargetsFinderByLayer.Targets.Count > 0 && (context.TargetsFinderByLayer.Targets[0].transform.position - context.transform.position).magnitude < 2f)
            {
                context.TransitionToState(context.AttackingState);
            }
        }

        public override void Exit(EnemyStateContext context)
        {
            // Logic for exiting the pursuing state
        }
    }
}