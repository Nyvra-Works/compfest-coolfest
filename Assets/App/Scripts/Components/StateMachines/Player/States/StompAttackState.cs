using UnityEngine;

namespace StateMachines.Player.States
{
    public class StompAttackState : AbstractState<MB_PlayerStateContext>
    {
        public override void Enter(MB_PlayerStateContext context)
        {
            context.OnEnterStompAttackHandler?.Invoke();
        }

        public override void Exit(MB_PlayerStateContext context)
        {
            context.OnExitStompAttackHandler?.Invoke();
        }
        float time = 0f;
        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            time += Time.deltaTime;
            if (time > context.BasicAttackSpeed)
            {
                time = 0f;
                context.TransitionToState(StateEnum.IdleState);
            }

            if (context.GroundTargetFinder.HasTargets())
            {
                context.TransitionToState(StateEnum.IdleState);
            }
        }
    }
}