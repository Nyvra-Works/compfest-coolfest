using UnityEngine;

namespace StateMachines.Player.States
{
    public class MovingState : AbstractState<MB_PlayerStateContext>
    {
        public override void Enter(MB_PlayerStateContext context)
        {
            Debug.Log("Entering Moving State");
        }

        public override void Exit(MB_PlayerStateContext context)
        {

        }

        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            var characterMovement = (MB_PlayerMovement)context.CharacterMovement;
            characterMovement.UpdateInState();
            
            if (context.CharacterMovementControl.TargetDirection == Vector3.zero)
            {
                context.TransitionToState(StateEnum.IdleState);
            }
        }
    }
}