using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace StateMachines.Player.States
{
    public class IdleState : AbstractState<MB_PlayerStateContext>
    {
        public override void Enter(MB_PlayerStateContext context)
        {
            Debug.Log("Entering Idle State");
        }

        public override void Exit(MB_PlayerStateContext context)
        {
        }

        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            if (context.CharacterMovementControl.TargetDirection != Vector3.zero)
            {
                context.TransitionToState(StateEnum.MovingState);
            }
        }
    }
}