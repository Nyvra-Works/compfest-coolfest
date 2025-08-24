namespace StateMachines.Player.States
{
    using UnityEngine;

    public class JumpAscendingState : AbstractState<MB_PlayerStateContext>
    {
        public override void Enter(MB_PlayerStateContext context)
        {
            context.OnEnterJumpHandler?.Invoke();

            _time = 0;

            _playerMovement = (MB_PlayerMovement)context.CharacterMovement;

        }

        public override void Exit(MB_PlayerStateContext context)
        {
        }
        float _time = 0;
        MB_PlayerMovement _playerMovement;
        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            // allow player to move
            _playerMovement.UpdateInState();

            _time += Time.deltaTime;
            if (_time < 0.1)
            {
                return;
            }


            if (context.GroundTargetFinder.HasTargets())
            {
                context.TransitionToState(StateEnum.IdleState);
            }

            if (context.Rigidbody.linearVelocity.y <= 0)
            {
                Debug.Log("I am no longer ascending, transitioning to descending state.", context.gameObject);
                context.TransitionToState(StateEnum.JumpDescendingState);
            }

            if (context.CombatInput.IsSpecial3Attacking)
            {
                context.TransitionToState(StateEnum.StompAttackState);
            }
        }
    }
}