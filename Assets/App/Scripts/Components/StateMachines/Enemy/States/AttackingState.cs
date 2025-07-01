using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class AttackingState : BaseState
    {
        public override void Enter(EnemyStateContext context)
        {
            Debug.Log("Entering Attacking State");

            context.CharacterMovement.OverrideStopWalk = true;
        }

        public override void UpdateExecute(EnemyStateContext context)
        {
            if (context.TargetsFinderByLayer.Targets.Count == 0)
            {
                context.TransitionToState(context.IdleState);
            }
            if ((context.TargetsFinderByLayer.Targets[0].transform.position - context.transform.position).magnitude >= context.StoppingDistance)
            {
                context.TransitionToState(context.PursuingState);
            }
        }

        public override void Exit(EnemyStateContext context)
        {
            // Logic for exiting the attacking state
            context.CharacterMovement.OverrideStopWalk = false;
        }
    }
}