using System;
using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class AttackingState : BaseState
    {
        MB_EnemyStateContext _context;
        public override void Enter(MB_EnemyStateContext context)
        {
            Debug.Log("Entering Attacking State");
            context.Movement.FullStop();
            _context = context;
            MB_SceneBoundHealthController.OnDamageTakenHandler += OnTakenDamage;
        }
        void OnTakenDamage()
        {
            _context.TransitionToState(_context.SoaringState);
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
            
            MB_SceneBoundHealthController.OnDamageTakenHandler -= OnTakenDamage;
        }
    }
}