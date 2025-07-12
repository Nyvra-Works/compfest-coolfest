using UnityEngine;

namespace StateMachines.Player.States
{
    public class MovingState : AbstractState<MB_PlayerStateContext>
    {
        MB_PlayerMovement _playerMovement;
        public override void Enter(MB_PlayerStateContext context)
        {
            // Debug.Log("Entering Moving State");
        }

        public override void Exit(MB_PlayerStateContext context)
        {

        }

        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            _playerMovement = (MB_PlayerMovement)context.CharacterMovement;
            _playerMovement.UpdateInState();

            if (context.CharacterMovementControl.TargetDirection == Vector3.zero)
            {
                context.TransitionToState(StateEnum.IdleState);
            }

            // allow player to move while moving
            if (context.CombatInput.IsBasicAttacking)
            {
                context.TransitionToState(StateEnum.BasicAttackState);
            }
        }
    }
}