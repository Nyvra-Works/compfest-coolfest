using System;
using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class AttackingState : BaseState
    {
        public override void Enter(MB_EnemyStateContext context)
        {
            Debug.Log("Entering Attacking State");

            context.OnAttackingEnter?.Invoke();
        }

        public override void UpdateExecute(MB_EnemyStateContext context)
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

        public override void Exit(MB_EnemyStateContext context)
        {
            // Logic for exiting the attacking state
            context.OnAttackingExit?.Invoke();
        }
    }
}