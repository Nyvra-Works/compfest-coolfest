using System;
using System.Collections;
using UnityEngine;

namespace StateMachines.Enemy.States
{
    public class SoaringState : BaseState
    {
        IEnumerator CheckCollisionWithGround(MB_EnemyStateContext context)
        {
            yield return new WaitForSeconds(0.1f);
            if (context.CollisionTargetFinderByLayer.Targets.Count > 0)
            {
                // context.TransitionToState(context.IdleState);
                OnLandingHandler.Invoke(context);
            }
            yield return null;
        }
        public override void Enter(MB_EnemyStateContext context)
        {
            Debug.Log("Entering Soaring State");
        }

        public override void Exit(MB_EnemyStateContext context)
        {
        }

        public override void UpdateExecute(MB_EnemyStateContext context)
        {
            Debug.Log("Updating Soaring State");
            context.StartCoroutine(CheckCollisionWithGround(context));
        }

        event Action<MB_EnemyStateContext> OnLandingHandler = (context) => { context.TransitionToState(context.IdleState); };
    };
}