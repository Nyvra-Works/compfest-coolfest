using System.Net.Mime;
using UnityEngine;
using UnityEngine.AI;

namespace StateMachines.Enemy.States
{
    public class PursuingState: BaseState
    {
        public override void Enter(MB_EnemyStateContext context)
        {
            Debug.Log("Entering Pursuing State");
            ResetNavMeshDestination(context);
        }
        void ResetNavMeshDestination(MB_EnemyStateContext context)
        {
            context.NavMeshAgent.SetDestination(context.transform.position);
        }

        public override void UpdateExecute(MB_EnemyStateContext context)
        {

            if (context.TargetsFinderByLayer.Targets.Count == 0)
            {
                context.TransitionToState(context.IdleState);
            }
            if (context.TargetsFinderByLayer.Targets.Count > 0 && (context.TargetsFinderByLayer.Targets[0].transform.position - context.transform.position).magnitude < context.StoppingDistance)
            {
                context.TransitionToState(context.AttackingState);
            }
        }
        public override void FixedUpdateExecute(MB_EnemyStateContext context)
        {
            context.Movement.UpdateInState();
        }

        public override void Exit(MB_EnemyStateContext context)
        {
            // Logic for exiting the pursuing state
        }
    }
}