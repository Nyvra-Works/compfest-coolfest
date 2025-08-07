using UnityEngine;

namespace StateMachines.Player.States
{
    public class MovingState : AbstractState<MB_PlayerStateContext>
    {
        MB_PlayerMovement _playerMovement;
        public override void Enter(MB_PlayerStateContext context)
        {
            // Debug.Log("Entering Moving State");

            _playerMovement = (MB_PlayerMovement)context.CharacterMovement;
        }

        public override void Exit(MB_PlayerStateContext context)
        {

        }

        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            // allow player to move
            _playerMovement.UpdateInState();

            if (context.CharacterMovementControl.TargetDirection == Vector3.zero)
            {
                context.TransitionToState(StateEnum.IdleState);
            }

            // allow player to basic attack while moving
            if (context.CombatInput.IsBasicAttacking)
            {
                context.TransitionToState(StateEnum.BasicAttackState);
            }

            // allow player to headbutt attack while moving
            if (context.CombatInput.IsSpecial1Attacking)
            {
                context.TransitionToState(StateEnum.HeadbuttAttackAscendingState);
            }

            // allow player to jump while moving
            if (Input.GetButtonDown("Jump"))
            {
                context.TransitionToState(StateEnum.JumpAscendingState);
            }
        }
    }
}