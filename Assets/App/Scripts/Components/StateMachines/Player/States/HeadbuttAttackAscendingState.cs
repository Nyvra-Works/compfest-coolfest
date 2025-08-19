using System;
using System.Collections;
using UnityEngine;

namespace StateMachines.Player.States
{
    public class HeadbuttAttackAscendingState : AbstractState<MB_PlayerStateContext>
    {
        float _time = 0;
        public override void Enter(MB_PlayerStateContext context)
        {
            // Debug.Log("Entering Headbutt Attack Ascending State");
            // stop any horizontal movement
            context.CharacterMovement.FullStop();

            context.HeadbuttJumpHandler?.Invoke();

            _time = 0;
        }


        public override void Exit(MB_PlayerStateContext context)
        {
            // Debug.Log("Exiting Headbutt Attack Ascending State");
            context.HeadbuttStayAscendingHandler?.Invoke();
        }

        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            // Invoke this so the headbutt damage can be dealt
            // Debug.Log("headbutt detects:" + context.HeadButtTargetFinder.HasTargets());
            _time += Time.deltaTime;
            if (_time < 0.1)
            {
                return;
            }
            if (context.HeadButtTargetFinder.HasTargets())
            {
                Debug.Log("I just headbutt something valid, transitioning to descending state.", context.gameObject);
                context.TransitionToState(StateEnum.HeadbuttAttackDescendingState);
            }
            if (context.Rigidbody.linearVelocity.y <= 0)
            {
                Debug.Log("I am no longer ascending, transitioning to descending state.", context.gameObject);
                context.TransitionToState(StateEnum.HeadbuttAttackDescendingState);
            }
        }
    }
}