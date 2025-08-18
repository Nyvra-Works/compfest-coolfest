namespace StateMachines.Player.States
{
    using UnityEngine;

    public class JumpDescendingState : AbstractState<MB_PlayerStateContext>
    {
        public override void Enter(MB_PlayerStateContext context)
        {

        }

        public override void Exit(MB_PlayerStateContext context)
        {
        }
        MB_PlayerMovement _playerMovement;
        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            // allow player to move
            _playerMovement = (MB_PlayerMovement)context.CharacterMovement;

            _playerMovement.UpdateInState();

            if (context.GroundTargetFinder.HasTargets())
            {
                context.TransitionToState(StateEnum.IdleState);
            }
        }
    }
}